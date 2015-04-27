clc
clear
%% 网络结构建立
t1=clock;
%读取数据
load RFLzus

%节点个数
inputnum=4;
hiddennum=5;
outputnum=1;

%随机选取1410个数据作为训练数据和30个数据作为预测数据
Train_in=RFLzus(1:800,1:4)';
Train_out=RFLzus(1:800,5)';

%训练数据归一化
[inputn,inputps]=mapminmax(Train_in);
[outputn,outputps]=mapminmax(Train_out);

%训练数据输入
X=inputn;
%训练数据输出
Y=outputn;

%BP神经网络构建
net=newff(X,Y,hiddennum);

%% 遗传算法参数初始化
maxgen=30;                         %进化代数，即迭代次数
sizepop=30;                        %种群规模
pcross=0.6;                       %交叉概率选择，0和1之间
pmutation=0.01;                    %变异概率选择，0和1之间

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
net.b{2}=B2;
%net.b{2}=reshape(B2,outputnum,1);

%网络参数设置（迭代次数，学习率，目标）
net.trainParam.epochs=1000;
net.trainParam.lr=0.1;
net.trainParam.goal=0.001;

%BP神经网络训练
net=train(net,X,Y);

%选取1231到1410作为测试数据的输入，1411到1440作为输出
input_test=RFLzus(821:850,1:4)';
output_test=RFLzus(821:850,5)';

%测试数据归一化
[inputn_test,input_testzps]=mapminmax(input_test);
[outputn_test,output_testzps]=mapminmax(output_test);

%BP神经网络预测输出
an=sim(net,inputn_test);

%预测输出数据反归一化
GABPoutput=mapminmax('reverse',an,output_testzps);
%BPoutput(1)=340;
E=GABPoutput-output_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);
RE=E./output_test  %相对误差
disp(['程序运行时间：',num2str(etime(clock,t1))]);

%网络预测结果图形
figure(2)
plot(GABPoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5)
hold on
plot(output_test,'o-b','markerfacecolor','b','markersize',5);
legend('GABP预测输出','期望输出')
title('GABP网络预测输出','fontsize',10)
ylabel('煤气流量','fontsize',10)
xlabel('时间/m','fontsize',10)
% plot(GABPoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5);
% hold on;
% plot(output_test,'o-b','markerfacecolor','b','markersize',5);
% legend('The result of GABP','Expected output')
% title('The prediction of GABP','fontsize',10)
% ylabel('Gas amount/km3','fontsize',10)
% xlabel('Time/min','fontsize',10)


%网络预测误差图形
figure(3)
line([0,30],[0,0])
hold on
plot(RE,'s-r','linewidth',1,'markerfacecolor','r')
title('GABP预测相对误差','fontsize',10)
ylabel('误差','fontsize',10)
xlabel('时间/m','fontsize',10)
box on
% plot(RE,'s-r','linewidth',1,'markerfacecolor','r')
% hold on
% line([0,30],[0,0])
% title('The prediction relative error of GABP','fontsize',10)
% ylabel('Relative error','fontsize',10)
% xlabel('Time/min','fontsize',10)
