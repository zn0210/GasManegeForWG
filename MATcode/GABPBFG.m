%%用GABP方法预测BFG效果不好，慎用
clc
clear
%% 网络结构建立
%读取数据
load BFGTpre;
BFGWL=BFGTpre;

B=BFGWL;
[m,n]=size(B);
for i=1:30:length(B)
    C(:,(i-1)/30+1)=B(i:i+29,:);
end
D=C';
for i=1:36
    p(i,:)=[D(i,:),D(i+1,:),D(i+2,:),D(i+3,:)];
end
%训练数据输入输出
X=p(1:35,:)';
Y=D(2:36,:)';
%训练数据归一化
[inputn,inputps]=mapminmax(X);
[outputn,outputps]=mapminmax(Y);

input=inputn;
output=outputn;

%训练数据输入
X=input;
%训练数据输出
Y=output;

%网络结构初始化，用当前点前120个数据预测后30个数据
inputnum=120;
outputnum=30;
hiddennum=3;

%BP神经网络构建
net=newff(X,Y,hiddennum);

%% 遗传算法参数初始化
maxgen=10;                         %进化代数，即迭代次数
sizepop=10;                        %种群规模
pcross=0.3;                       %交叉概率选择，0和1之间
pmutation=0.1;                    %变异概率选择，0和1之间

%节点总数
numsum=inputnum*hiddennum+hiddennum+hiddennum*outputnum+outputnum;

lenchrom=ones(1,numsum);        
bound=[-3*ones(numsum,1) 3*ones(numsum,1)];    %数据范围

%------------------------------------------------------种群初始化--------------------------------------------------------
individuals=struct('fitness',zeros(1,sizepop), 'chrom',[]);  %将种群信息定义为一个结构体
avgfitness=[];                      %每一代种群的平均适应度
bestfitness=[];                     %每一代种群的最佳适应度
bestchrom=[];                       %适应度最好的染色体
%初始化种群
for i=1:sizepop
    %随机产生一个种群
    individuals.chrom(i,:)=Code(lenchrom,bound);    %编码（binary和grey的编码结果为一个实数，float的编码结果为一个实数向量）
    x=individuals.chrom(i,:);
    %计算适应度
    individuals.fitness(i)=fun(x,inputnum,hiddennum,outputnum,net,X,Y);   %染色体的适应度,调用fun函数，适应度函数
end

%找最好的染色体
[bestfitness bestindex]=min(individuals.fitness);
bestchrom=individuals.chrom(bestindex,:);  %最好的染色体
avgfitness=sum(individuals.fitness)/sizepop; %染色体的平均适应度
% 记录每一代进化中最好的适应度和平均适应度
trace=[avgfitness bestfitness]; 
 
%% 迭代求解最佳初始阀值和权值
% 进化开始
for i=1:maxgen
    %i
    % 选择,调用Select函数
    individuals=Select(individuals,sizepop); 
    avgfitness=sum(individuals.fitness)/sizepop;
    %交叉，调用Cross函数
    individuals.chrom=Cross(pcross,lenchrom,individuals.chrom,sizepop,bound);
    % 变异，调用Mutation函数
    individuals.chrom=Mutation(pmutation,lenchrom,individuals.chrom,sizepop,i,maxgen,bound);
    
    % 计算适应度 
    for j=1:sizepop
        x=individuals.chrom(j,:); %解码
        individuals.fitness(j)=fun(x,inputnum,hiddennum,outputnum,net,X,Y);   
    end
    
  %找到最小和最大适应度的染色体及它们在种群中的位置
    [newbestfitness,newbestindex]=min(individuals.fitness);
    [worestfitness,worestindex]=max(individuals.fitness);
    % 代替上一次进化中最好的染色体
    if bestfitness>newbestfitness
        bestfitness=newbestfitness;
        bestchrom=individuals.chrom(newbestindex,:);
    end
    individuals.chrom(worestindex,:)=bestchrom;
    individuals.fitness(worestindex)=bestfitness;
    
    avgfitness=sum(individuals.fitness)/sizepop;
    
    trace=[trace;avgfitness bestfitness]; %记录每一代进化中最好的适应度和平均适应度

end
%% 遗传算法结果分析 
 figure(1)
[r c]=size(trace);
plot([1:r]',trace(:,2),'b--');
title(['适应度曲线  ' '终止代数＝' num2str(maxgen)]);
xlabel('进化代数');ylabel('适应度');
legend('平均适应度','最佳适应度');
%disp('适应度                   变量');

%% 把最优初始阀值权值赋予网络预测
% %用遗传算法优化的BP网络进行值预测
x=bestchrom;
w1=x(1:inputnum*hiddennum);
B1=x(inputnum*hiddennum+1:inputnum*hiddennum+hiddennum);
w2=x(inputnum*hiddennum+hiddennum+1:inputnum*hiddennum+hiddennum+hiddennum*outputnum);
B2=x(inputnum*hiddennum+hiddennum+hiddennum*outputnum+1:inputnum*hiddennum+hiddennum+hiddennum*outputnum+outputnum);

net.iw{1,1}=reshape(w1,hiddennum,inputnum);
net.lw{2,1}=reshape(w2,outputnum,hiddennum);
net.b{1}=reshape(B1,hiddennum,1);
%net.b{2}=B2;
net.b{2}=reshape(B2,outputnum,1);

%网络参数设置（迭代次数，学习率，目标）
net.trainParam.epochs=1000;
net.trainParam.lr=0.1;
net.trainParam.goal=0.001;

%BP神经网络训练
net=train(net,X,Y);

load BWinput_test;
load BWoutput_test;
%预测输入归一化
bx=mapminmax('apply',BWinput_test,inputps);

%BP神经网络预测输出
an=sim(net,bx);
%yuce(i)=y(k);
%y=zeros(1,N);
%net=zeros(1,n);
%net_ab=zeros(1,n);
%预测输出反归一化
ynn=mapminmax('reverse',an,outputps);
E=ynn-BWoutput_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);

%网络预测结果图形
figure(2)
plot(ynn,'*-r')
hold on
plot(BWoutput_test,'.-b');
legend('预测输出','期望输出')
title('GABP网络预测输出','fontsize',12)
ylabel('煤气流量','fontsize',12)
xlabel('时间/m','fontsize',12)

%网络预测误差图形
figure(3)
bar(E,'b')
title('GABP网络预测误差','fontsize',12)
ylabel('误差','fontsize',12)
xlabel('时间/m','fontsize',12)
