% function pso+bp
clc
clear all

t1=clock;
%�������أ��ȷ�¯����
load RFLzus;
x=RFLzus;
AllSamIn=x(1:800,1:4)';
AllSamOut=x(1:800,5)';

% Ԥ�������ݣ�����premnmx�������й�һ����[-1,1]
global minAllSamOut;
global maxAllSamOut;
[AllSamInn,minAllSamIn,maxAllSamIn,AllSamOutn,minAllSamOut,maxAllSamOut] = premnmx(AllSamIn,AllSamOut);
% AllSamInn ��һ���������
%%
TrainSamIn=AllSamInn;
TrainSamOut=AllSamOutn;

global Ptrain;
Ptrain = TrainSamIn;
global Ttrain;
Ttrain = TrainSamOut;

Ptest = TrainSamIn;
Ttest = TrainSamOut;

%% ��ʼ��BP�������
global indim;
indim=4;
global hiddennum;
hiddennum=3;
global outdim;
outdim=1;

%% ��ʼ��PSO���� wΪ����Ȩ�أ�c1,c2�Ǽ���ϵ��
vmax=1; % ����ٶ�
minerr=0.05; % ��С���
wmax=0.90;
wmin=0.40;
global itmax; %����������
itmax=50;
c1=2.05;
c2=2.05;

for iter=1:itmax
    W(iter)=wmax-((wmax-wmin)/itmax)*iter; % w��0.9�����Եݼ���0.3
end

% ��ʼ���ӷ�Χ(a,b)
a=-1;
b=1;
%����(m,n)
m=-1;
n=1;
global N; % ��������Ϊ30
N=30;
global D; % ���ӳ���
D=(indim+1)*hiddennum+(hiddennum+1)*outdim; % �Ż��������������е�Ȩֵ����ֵ�����Գ���+1�� % 4 3 1 ��ʱ��D Ϊ19
% ��ʼ������λ��
rand('state',sum(100*clock));
X=a+(b-a)*rand(N,D,1);
% ��ʼ�������ٶ�
V=m+(n-m)*rand(N,D,1);
% 
global fvrec;
MinFit=[];
BestFit=[];

global net;
net=newff(minmax(Ptrain),[hiddennum,outdim],{'tansig','purelin'});
fitness=fitcal(X,net,indim,hiddennum,outdim,D,Ptrain,Ttrain,minAllSamOut,maxAllSamOut); %����ֵ ÿһ���������Ӧֵ

fvrec(:,1,1)=fitness(:,1,1);%����ֵ��ÿһ���������Ӧֵ����һ��

[C,I]=min(fitness(:,1,1)); %������С��ӦֵC�� �������� I
MinFit=[MinFit C];  %��һ����local bestfitness
BestFit=[BestFit C]; %��һ����global bestfitness
L(:,1,1)=fitness(:,1,1); %��¼ÿһ�������Ž�
B(1,1,1)=C; %��¼��С��Ӧ��ֵ
gbest(1,:,1)=X(I,:,1); %ȫ������X


for p=1:N
    G(p,:,1)=gbest(1,:,1); %ÿ�������ȫ������
end
for i=1:N;
    pbest(i,:,1)=X(i,:,1); %��һ������ʷ��þ����Լ�
end
V(:,:,2)=W(1)*V(:,:,1)+c1*rand*(pbest(:,:,1)-X(:,:,1))+c2*rand*(G(:,:,1)-X(:,:,1));

% ��ÿ�����ӵ��ٶ����ƣ��������趨������ٶ�
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
    % �����µ�����λ��
    fitness=fitcal(X,net,indim,hiddennum,outdim,D,Ptrain,Ttrain,minAllSamOut,maxAllSamOut); %����ֵ ÿһ���������Ӧֵ
    fvrec(:,1,j)=fitness(:,1,j); %����ֵ ÿһ���������Ӧֵ ��j��
    [C,I]=min(fitness(:,1,j));
    
    MinFit=[MinFit C]; %��¼ÿ������С��Ӧֵ
    BestFit=[BestFit min(MinFit)]; %��¼ȫ��ȫ�������Ӧֵ
    
    L(:,1,j)=fitness(:,1,j); %��¼the fitness of particle of every iterations
    B(1,1,j)=C;              %��¼the minimum fitness of particle
    gbest(1,:,j)=X(I,:,j);
    [C,I]=min(B(1,1,:));
    % ��֤gbest��֮ǰ���������е�����ֵ
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

% �������
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

% ѵ�����ݷ���һ��
testsamout = postmnmx(sim(net,Ptest),minAllSamOut,maxAllSamOut);
% ѵ�����ݺ�ʵ�����ݾ�����
realtesterr=mse(testsamout-Ttest);

%���������������
%Ԥ����30���ӵķ�����
% EvaDataIn=x(821:850,1:4)';
% EvaDataOut=x(821:850,5)';

%Ԥ���ȷ�¯һ�����ڵķ���������63����ֵ
EvaDataIn=x(821:883,1:4)';
EvaDataOut=x(821:883,5)';
%�������ݹ�һ��
[EvaDataInn,minEvaDataIn,maxEvaDataIn,EvaDataOutn,minEvaDataOut,maxEvaDataOut] = premnmx(EvaDataIn,EvaDataOut);
%�������ݽ�������ģ��
EvaSamOut5netn = sim(net,EvaDataInn);
%��������������һ��
EvaSamOut5net = postmnmx(EvaSamOut5netn,minEvaDataOut,maxEvaDataOut);
%Ԥ�������ʵ���������
E=EvaSamOut5net-EvaDataOut;
MSERFL=mse(E);
SSERFL=sse(E);
MAERFL=mae(E);
RE=E./EvaDataOut  %������
disp(['��������ʱ�䣺',num2str(etime(clock,t1))]);

figure(1)
plot(BestFit);
title('���Ÿ�����Ӧ��ֵ','fontsize',10);
xlabel('��������','fontsize',10);
ylabel('��Ӧ��ֵ','fontsize',10);

figure(2)
plot(EvaSamOut5net,'s-r','linewidth',1,'markerfacecolor','r','markersize',3);
hold on;
plot(EvaDataOut,'o-b','markerfacecolor','b','markersize',3);
legend('PSOBPԤ�����','�������','fontsize',10)
title('PSOBP����ú��Ԥ��','fontsize',10)
ylabel('ú������/km3','fontsize',10)
xlabel('ʱ��/m','fontsize',10)
% legend('The result of PSOBP','Expected output')
% title('The prediction of PSOBP','fontsize',10)
% ylabel('Gas amount/km3','fontsize',10)
% xlabel('Time/min','fontsize',10)

figure(3)
plot(RE,'s-r','linewidth',1,'markerfacecolor','r','markersize',3)
hold on
line([0,63],[0,0])
title('PSOBPԤ��������','fontsize',10)
ylabel('������','fontsize',10)
xlabel('ʱ��/min','fontsize',10)
% title('The prediction relative error of PSOBP','fontsize',10)
% ylabel('Relative error','fontsize',10)
% xlabel('Time/min','fontsize',10)
