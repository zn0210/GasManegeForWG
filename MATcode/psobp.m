% function pso+bp
clc
clear all

t1=clock;
%数据下载，热风炉数据
load RFLzus;
x=RFLzus;
AllSamIn=x(1:800,1:4)';
AllSamOut=x(1:800,5)';

% 预处理数据，采用premnmx函数进行归一化至[-1,1]
global minAllSamOut;
global maxAllSamOut;
[AllSamInn,minAllSamIn,maxAllSamIn,AllSamOutn,minAllSamOut,maxAllSamOut] = premnmx(AllSamIn,AllSamOut);
% AllSamInn 归一化后的输入
%%
TrainSamIn=AllSamInn;
TrainSamOut=AllSamOutn;

global Ptrain;
Ptrain = TrainSamIn;
global Ttrain;
Ttrain = TrainSamOut;

Ptest = TrainSamIn;
Ttest = TrainSamOut;

%% 初始化BP网络参数
global indim;
indim=4;
global hiddennum;
hiddennum=3;
global outdim;
outdim=1;

%% 初始化PSO参数 w为惯量权重，c1,c2是加速系数
vmax=1; % 最大速度
minerr=0.05; % 最小误差
wmax=0.90;
wmin=0.40;
global itmax; %最大迭代次数
itmax=50;
c1=2.05;
c2=2.05;

for iter=1:itmax
    W(iter)=wmax-((wmax-wmin)/itmax)*iter; % w由0.9呈线性递减至0.3
end

% 初始粒子范围(a,b)
a=-1;
b=1;
%区间(m,n)
m=-1;
n=1;
global N; % 粒子数量为30
N=30;
global D; % 粒子长度
D=(indim+1)*hiddennum+(hiddennum+1)*outdim; % 优化参数个数，所有的权值和阈值（所以出现+1） % 4 3 1 的时候D 为19
% 初始化粒子位置
rand('state',sum(100*clock));
X=a+(b-a)*rand(N,D,1);
% 初始化粒子速度
V=m+(n-m)*rand(N,D,1);
% 
global fvrec;
MinFit=[];
BestFit=[];

global net;
net=newff(minmax(Ptrain),[hiddennum,outdim],{'tansig','purelin'});
fitness=fitcal(X,net,indim,hiddennum,outdim,D,Ptrain,Ttrain,minAllSamOut,maxAllSamOut); %返回值 每一个个体的适应值

fvrec(:,1,1)=fitness(:,1,1);%返回值，每一个个体的适应值，第一代

[C,I]=min(fitness(:,1,1)); %当代最小适应值C， 及其索引 I
MinFit=[MinFit C];  %第一代的local bestfitness
BestFit=[BestFit C]; %第一代的global bestfitness
L(:,1,1)=fitness(:,1,1); %记录每一代的最优解
B(1,1,1)=C; %记录最小适应度值
gbest(1,:,1)=X(I,:,1); %全局最优X


for p=1:N
    G(p,:,1)=gbest(1,:,1); %每个个体的全局最优
end
for i=1:N;
    pbest(i,:,1)=X(i,:,1); %第一代的历史最好就是自己
end
V(:,:,2)=W(1)*V(:,:,1)+c1*rand*(pbest(:,:,1)-X(:,:,1))+c2*rand*(G(:,:,1)-X(:,:,1));

% 对每个粒子的速度限制，不超过设定的最大速度
for ni=1:N
    for di=1:D
        if V(ni,di,2) > vmax
            V(ni,di,2) = vmax;
        elseif V(ni,di,2) < -vmax
            V(ni,di,2) = -vmax;
        else
            V(ni,di,2) = V(ni,di,2);
        end
    end
end

X(:,:,2)=X(:,:,1)+V(:,:,2);

for ni=1:N
    for di=1:D
        if X(ni,di,2) > 1
            X(ni,di,2) = 1;
        elseif V(ni,di,2) < -1
            X(ni,di,2) = -1;
        else
            X(ni,di,2) = X(ni,di,2);
        end
    end
end

%%
%******************************************************
for j=2:itmax
    disp('Iteration and Current Best Fitness')
    disp(j-1)
    disp(B(1,1,j-1))
    % 计算新的粒子位置
    fitness=fitcal(X,net,indim,hiddennum,outdim,D,Ptrain,Ttrain,minAllSamOut,maxAllSamOut); %返回值 每一个个体的适应值
    fvrec(:,1,j)=fitness(:,1,j); %返回值 每一个个体的适应值 第j代
    [C,I]=min(fitness(:,1,j));
    
    MinFit=[MinFit C]; %记录每代的最小适应值
    BestFit=[BestFit min(MinFit)]; %记录全部全局最好适应值
    
    L(:,1,j)=fitness(:,1,j); %记录the fitness of particle of every iterations
    B(1,1,j)=C;              %记录the minimum fitness of particle
    gbest(1,:,j)=X(I,:,j);
    [C,I]=min(B(1,1,:));
    % 保证gbest是之前所有粒子中的最优值
    if B(1,1,j)<=C
        gbest(1,:,j)=gbest(1,:,j);
    else
        gbest(1,:,j)=gbest(1,:,I);
    end
    if C<=minerr, break, end
    
    %
    if j>=itmax, break, end
    for p=1:N
        G(p,:,j)=gbest(1,:,j);
    end
    for i=1:N;
        [C,I]=min(L(i,1,:));
        if L(i,1,j)<=C
            pbest(i,:,j)=X(i,:,j);
        else
            pbest(i,:,j)=X(i,:,I);
        end
    end
    V(:,:,j+1)=W(j)*V(:,:,j)+c1*rand*(pbest(:,:,j)-X(:,:,j))+c2*rand*(G(:,:,j)-X(:,:,j));

    for ni=1:N
        for di=1:D
            if V(ni,di,j+1)>vmax
                V(ni,di,j+1)=vmax;
            elseif V(ni,di,j+1)<-vmax
                V(ni,di,j+1)=-vmax;
            else
                V(ni,di,j+1)=V(ni,di,j+1);
            end
        end
    end
    X(:,:,j+1)=X(:,:,j)+V(:,:,j+1);
    
    for ni=1:N
        for di=1:D
            if X(ni,di,j+1) > 1
                X(ni,di,j+1) = 1;
            elseif V(ni,di,j+1) < -1
                X(ni,di,j+1) = -1;
            else
                X(ni,di,j+1) = X(ni,di,j+1);
            end
        end
    end 
end

disp('Iteration and Current Best Fitness')
disp(j)
disp(B(1,1,j))
disp('Global Best Fitness and Occurred Iteration')
[C,I] = min(B(1,1,:))

% 仿真过程
for t=1:hiddennum
    x2iw(t,:)=gbest(1,((t-1)*indim+1):t*indim,j);
end
for r=1:outdim
    x2lw(r,:)=gbest(1,(indim*hiddennum+1):(indim*hiddennum+hiddennum),j);
end
x2b=gbest(1,((indim+1)*hiddennum+1):D,j);
x2b1=x2b(1:hiddennum).';
x2b2=x2b(hiddennum+1:hiddennum+outdim).';

net.IW{1,1}=x2iw;
net.LW{2,1}=x2lw;
net.b{1}=x2b1;
net.b{2}=x2b2;

% 训练数据反归一化
testsamout = postmnmx(sim(net,Ptest),minAllSamOut,maxAllSamOut);
% 训练数据和实际数据均方差
realtesterr=mse(testsamout-Ttest);

%测试数据输入输出
%预测下30分钟的发生量
% EvaDataIn=x(821:850,1:4)';
% EvaDataOut=x(821:850,5)';

%预测热风炉一个周期的发生量，即63个点值
EvaDataIn=x(821:883,1:4)';
EvaDataOut=x(821:883,5)';
%测试数据归一化
[EvaDataInn,minEvaDataIn,maxEvaDataIn,EvaDataOutn,minEvaDataOut,maxEvaDataOut] = premnmx(EvaDataIn,EvaDataOut);
%测试数据进行网络模拟
EvaSamOut5netn = sim(net,EvaDataInn);
%测试输出结果反归一化
EvaSamOut5net = postmnmx(EvaSamOut5netn,minEvaDataOut,maxEvaDataOut);
%预测输出与实际数据误差
E=EvaSamOut5net-EvaDataOut;
MSERFL=mse(E);
SSERFL=sse(E);
MAERFL=mae(E);
RE=E./EvaDataOut  %相对误差
disp(['程序运行时间：',num2str(etime(clock,t1))]);

figure(1)
plot(BestFit);
title('最优个体适应度值','fontsize',10);
xlabel('进化次数','fontsize',10);
ylabel('适应度值','fontsize',10);

figure(2)
plot(EvaSamOut5net,'s-r','linewidth',1,'markerfacecolor','r','markersize',3);
hold on;
plot(EvaDataOut,'o-b','markerfacecolor','b','markersize',3);
legend('PSOBP预测输出','期望输出','fontsize',10)
title('PSOBP网络煤气预测','fontsize',10)
ylabel('煤气流量/km3','fontsize',10)
xlabel('时间/m','fontsize',10)
% legend('The result of PSOBP','Expected output')
% title('The prediction of PSOBP','fontsize',10)
% ylabel('Gas amount/km3','fontsize',10)
% xlabel('Time/min','fontsize',10)

figure(3)
plot(RE,'s-r','linewidth',1,'markerfacecolor','r','markersize',3)
hold on
line([0,63],[0,0])
title('PSOBP预测相对误差','fontsize',10)
ylabel('相对误差','fontsize',10)
xlabel('时间/min','fontsize',10)
% title('The prediction relative error of PSOBP','fontsize',10)
% ylabel('Relative error','fontsize',10)
% xlabel('Time/min','fontsize',10)
