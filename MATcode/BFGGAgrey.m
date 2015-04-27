%% GAWNN未实现
clc
clear
t1=clock;
%下载数据
load BFGgrey;
%通过第一列，第二列,第三列来预测最后一列值
X=BFGgrey(1:800,:)';
[n,m]=size(X);
[input,inputps]=mapminmax(X);
%for i=1:m
 %   z(1,i)=sum(input(1,1:i));
  %  z(2,i)=sum(input(2,1:i));
   % z(3,i)=sum(input(3,1:i));
    %z(4,i)=sum(input(4,1:i));
%end
y=input';

%网络参数初始化
a=0.45+rand(1)/4;
b1=0.45+rand(1)/4;
b2=0.45+rand(1)/4;
b3=0.45+rand(1)/4;

%学习速率
u1=0.1;
u2=0.1;
u3=0.1;

%根据权值公式取权值
t=1;
w11=a;
w21=-y(1,1);
w22=2*b1/a;
w23=2*b2/a;
w24=2*b3/a;
w31=1+exp(-a*t);
w32=1+exp(-a*t);
w33=1+exp(-a*t);
w34=1+exp(-a*t);
theta=(1+exp(-a*t))*(b1*y(1,2)/a+b2*y(1,3)/a+b3*y(1,4)/a-y(1,1));

%记录误差
E=zeros(1,100);
%网络循环
for j=1:100
%循环迭代
for i=1:m
    t=i;
    LB_b=1/(1+exp(-w11*t));   %LB层输出
    LC_c1=LB_b*w21;           %LC层输出
    LC_c2=y(i,2)*LB_b*w22;    %LC层输出
    LC_c3=y(i,3)*LB_b*w23;    %LC层输出
    LC_c4=y(i,4)*LB_b*w24;
    LD_d=w31*LC_c1+w32*LC_c2+w33*LC_c3+w34*LC_c4;    %LD层输出
    theta=(1+exp(-w11*t))*(w22*y(i,2)/2+w23*y(i,3)/2+w24*y(i,4)/2-y(1,1));   %阀值
    ym=LD_d-theta;   %网络输出值
    yc(i)=ym;
    %计算误差
    error=ym-y(i,1);
    E(j)=E(j)+error;
   % 权值修正
    error1=error*(1+exp(-w11*t));
    error2=error*(1+exp(-w11*t));
    error3=error*(1+exp(-w11*t));
    error4=error*(1+exp(-w11*t));
    error5=(1/(1+exp(-w11*t)))*(1-1/(1+exp(-w11*t)))*(w21*error1+w22*error2+w23*error3+w24*error4);
    
    %修改权值
    w22=w22-u1*error2*LB_b;
    w23=w23-u2*error3*LB_b;
    w24=w24-u3*error4*LB_b;
    w11=w11+a*t*error5;
end
end
%% 遗传算法参数初始化
maxgen=50;                         %进化代数，即迭代次数
sizepop=30;                        %种群规模
pcross=0.6;                       %交叉概率选择，0和1之间
pmutation=0.01;                    %变异概率选择，0和1之间

%节点总数
numsum=4*4+4+4*1+1;

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
    individuals.fitness(i)=fun(x,4,4,1,net,X,Y);   %染色体的适应度,调用fun函数，适应度函数
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