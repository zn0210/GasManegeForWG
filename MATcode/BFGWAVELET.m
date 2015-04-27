clear
clc
% function bw=BFGWAVELET()
%% 小波神经网络的时间序列预测
tic;
t1=clock;   %获取当前时间
%下载数据
load BFGTpre;
B=BFGTpre;

[m,n]=size(B);
for i=1:30:length(B)
    C(:,(i-1)/30+1)=B(i:i+29,:);    %间隔30个取数
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

input=inputn';
output=outputn';

%网络结构初始化，用当前点前120个数据预测后30个数据
M=120;
N=30;
n=3;

%权值和参数学习率
lr1=0.01;
lr2=0.001;
maxgen=100;%网络迭代次数

%网络权值初始化
Wjk=randn(n,M);
%Wjk_1=Wjk;Wjk_2=Wjk_1;
Wij=randn(N,n);
%Wij_1=Wij;Wij_2=Wij_1;
%% 将伸缩因子a初始化在[0,1]之间，将[0,0.5]和(0.5,1)区间上的a随机映射到区间[0,1]和(1,5];
 %  将平移因子b初始化在[-1,1]之间，乘以10，使得区间为[-10,10];
a=rand(1,n);
ind1=find(a>=0&a<=0.5);
indnum1=length(ind1);
a(1,ind1)=0+(1-0)*rand(1,indnum1);
ind2=find(a>0.5&a<=1);
indnum2=length(ind2);
a(1,ind2)=1+(5-1)*rand(1,indnum2);
a_1=a;a_2=a_1;
b=unifrnd(-1,1,1,n);
b_1=b*20;b_2=b_1;
%%
%节点初始化
y=zeros(1,N);
net=zeros(1,n);
net_ab=zeros(1,n);

%权值学习增量初始化
d_Wjk=zeros(n,M);
d_Wij=zeros(N,n);
d_a=zeros(1,n);
d_b=zeros(1,n);

%% 网络训练
for i=1:maxgen
    
    %误差累计
    error(i)=0;
    
    % 循环训练
    for kk=1:size(input,1)
        x=input(kk,:);
        yqw=output(kk,:);
   
        for j=1:n
            for k=1:M
                net(j)=net(j)+Wjk(j,k)*x(k);
                net_ab(j)=(net(j)-b(j))/a(j);
            end
            temp=mymorlet(net_ab(j));
            for k=1:N
                y=y+Wij(k,j)*temp;   %小波函数
            end
        end
        
        %计算误差和
        error(i)=error(i)+sum(abs(yqw-y));
        
        %权值调整
        for j=1:n
            %计算d_Wij
            temp=mymorlet(net_ab(j));
            for k=1:N
                d_Wij(k,j)=d_Wij(k,j)-(yqw(k)-y(k))*temp;
            end
            %计算d_Wjk
            temp=d_mymorlet(net_ab(j));
            for k=1:M
                for l=1:N
                    d_Wjk(j,k)=d_Wjk(j,k)+(yqw(l)-y(l))*Wij(l,j) ;
                end
                d_Wjk(j,k)=-d_Wjk(j,k)*temp*x(k)/a(j);
            end
            %计算d_b
            for k=1:N
                d_b(j)=d_b(j)+(yqw(k)-y(k))*Wij(k,j);
            end
            d_b(j)=d_b(j)*temp/a(j);
            %计算d_a
            for k=1:N
                d_a(j)=d_a(j)+(yqw(k)-y(k))*Wij(k,j);
            end
            d_a(j)=d_a(j)*temp*((net(j)-b(j))/b(j))/a(j);
        end
        
        %权值参数更新      
%         Wij=Wij-lr1*d_Wij;%梯度学习算法
%         Wjk=Wjk-lr1*d_Wjk;
%         b=b-lr2*d_b;
%         a=a-lr2*d_a;
        h=0.3;
        Wjk0=reshape(Wjk,1,3*120);
        Wij0=reshape(Wij,1,30*3);
        for mm=1:89
        Wij=Wij-lr1*d_Wij+h*(Wij0(1,mm+1)-Wij0(1,mm));% 增加动量项提高网络学习速率
        end
        for nn=1:359
        Wjk=Wjk-lr1*d_Wjk+h*(Wjk0(1,nn+1)-Wjk0(1,nn));
        end
        b=b-lr2*d_b+h*(b_1-b_2);
        a=a-lr2*d_a+h*(a_1-a_2);
        end
  
        d_Wjk=zeros(n,M);
        d_Wij=zeros(N,n);
        d_a=zeros(1,n);
        d_b=zeros(1,n);

        y=zeros(1,N);
        net=zeros(1,n);
        net_ab=zeros(1,n);
        
%         Wjk_1=Wjk;Wjk_2=Wjk_1;
%         Wij_1=Wij;Wij_2=Wij_1;
%         a_1=a;a_2=a_1;
%         b_1=b;b_2=b_1;
end
load BWinput_testpre;
load BWoutput_test;
%预测输入归一化
x=mapminmax('apply',BWinput_testpre,inputps);
x=x';
%网络预测
 for j=1:1:n
     for k=1:1:M
         net(j)=net(j)+Wjk(j,k)*x(1);
         net_ab(j)=(net(j)-b(j))/a(j);
     end
     temp=mymorlet(net_ab(j));
     for k=1:N
         y(k)=y(k)+Wij(k,j)*temp ; 
     end
 end
%yuce(i)=y(k);
%y=zeros(1,N);
%net=zeros(1,n);
%net_ab=zeros(1,n);
%预测输出反归一化
ynn=mapminmax('reverse',y(k),outputps);
E=ynn-BWoutput_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);
RE=E./BWoutput_test  %相对误差
disp(['程序运行时间：',num2str(etime(clock,t1))]);
% fid=fopen('bwl.txt','wt');
% fidd=fopen('bwlo.txt','wt');
% fprintf(fid,'%g\n',ynn);
% fprintf(fidd,'%g\n',BWoutput_test);
% fclose(fid);
% fclose(fidd);

% 结果分析
figure(1)
plot(error,'-');
title('网络进化过程','fontsize',12);
xlabel('进化次数');
ylabel('预测误差累积');

figure(2)
plot(ynn,'s-r','linewidth',1,'markerfacecolor','r','markersize',5);
hold on
plot(BWoutput_test,'o-b','markerfacecolor','b','markersize',5);
title('动量改进的小波神经网络高炉煤气发生量预测','fontsize',10);
legend('煤气流量预测值','煤气流量实际值','fontsize',10);
xlabel('时间点','fontsize',10);
ylabel('煤气流量','fontsize',10);

x=0:0.01:30;
y=0;
figure(3)
plot(x,y,'-b','linewidth',3);
hold on
plot(RE,'s-r','linewidth',1,'markerfacecolor','r');
title('相对误差图','fontsize',10);
xlabel('时间/min','fontsize',10);
ylabel('相对误差','fontsize',10);
% bw=ynn;

