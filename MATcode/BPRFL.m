clc
clear
%% 网络结构建立
t1=clock;
%读取数据
load RFLzus
%随机选取500个数据作为训练数据和50个数据作为预测数据
Train=RFLzus(1:800,:)';
Test=RFLzus(821:850,:)';

%训练数据归一化
[inputn,inputps]=mapminmax(Train);

%数据累加
[n1,m1]=size(inputn);
for i=1:m1
   x(1,i)=sum(inputn(1,1:i));
   x(2,i)=sum(inputn(2,1:i));
   x(3,i)=sum(inputn(3,1:i));
   x(4,i)=sum(inputn(4,1:i));
   x(5,i)=sum(inputn(5,1:i));
end
a=x';
%训练数据输入
X=a(1:800,1:4);
%训练数据输出
Y=a(1:800,5);


%BP神经网络构建
net=newff(X',Y',3);
%网络参数设置（迭代次数，学习率，目标）
net.trainParam.epochs=1000;
net.trainParam.lr=0.1;
net.trainParam.goal=0.001;

%BP神经网络训练
net=train(net,X',Y');

%选取501到550作为测试数据的输入，501到550作为输出
input_test=Test(1:4,1:30);
output_test=Test(5,1:30);
%测试数据归一化
[inputn_test,input_testzps]=mapminmax(input_test);
[outputn_test,output_testzps]=mapminmax(output_test);
[n3,m3]=size(inputn_test);
for i=1:m3
   z(1,i)=sum(inputn(1,1:i));
   z(2,i)=sum(inputn(2,1:i));
   z(3,i)=sum(inputn(3,1:i));
   z(4,i)=sum(inputn(4,1:i));
   z(5,i)=sum(inputn(5,1:i));
end
zz=z(1:4,:);
%BP神经网络预测输出
an=sim(net,zz);
ys=an;
for j=30:-1:2
    ys(j)=an(j)-an(j-1);
end

%预测输出数据反归一化
BPoutput=mapminmax('reverse',ys',output_testzps);
E=BPoutput'-output_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);
RE=E./output_test  %相对误差
disp(['程序运行时间：',num2str(etime(clock,t1))]);
%RMSE=sqrtm(MSE);%均方根误差
%NMSE=MSE/SSE;%正规化均方误差

%网络预测结果图形
figure(1)
plot(BPoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5)
hold on
plot(output_test,'o-b','markerfacecolor','b','markersize',5);
legend('BP预测输出','期望输出')
title('BP网络预测输出','fontsize',10)
ylabel('煤气流量','fontsize',10)
xlabel('时间/m','fontsize',10)
% plot(BPoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5);
% hold on;
% plot(output_test,'o-b','markerfacecolor','b','markersize',5);
% legend('The result of BP','Expected output')
% title('The prediction of BP','fontsize',10)
% ylabel('Gas amount/km3','fontsize',10)
% xlabel('Time/min','fontsize',10)

figure(2)
plot(RE,'s-r','linewidth',1,'markerfacecolor','r')
hold on
line([0,30],[0,0])
title('BP网络预测相对误差','fontsize',10)
ylabel('误差','fontsize',10)
xlabel('时间/m','fontsize',10)
% plot(RE,'s-r','linewidth',1,'markerfacecolor','r')
% hold on
% line([0,30],[0,0])
% title('The prediction relative error of BP','fontsize',10)
% ylabel('Relative error','fontsize',10)
% xlabel('Time/min','fontsize',10)