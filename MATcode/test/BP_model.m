
%清空环境变量
% clc
% clear

%%数据选择和归一化
%下载输入输出数据
% load data input output
%  load data input output


%随机选择1900组训练数据和100组预测数据

k=rand(1,2000);
[m,n]=sort(k);
input_train=input(n(1:1900),:)';
output_train=output(n(1:1900),:)';
input_test=input(n(1901:2000),:)';
output_test=output(n(1901:2000),:)';

%训练数据归一化
[inputn,inputs]=mapminmax(input_train);
[outputn,outputs]=mapminmax(output_train);

%%网络训练
%BP神经网络构建
net=newff(inputn,outputn,5);

%网络参数配置（迭代次数，学习率，目标）
net.trainParam.epochs=100;
net.trainParam.lr=0.1;
net.trainParam.goal=0.00004;

%BP神经网络训练
net=train(net,inputn,outputn);

%%BP神经网络预测
%预测数据归一化
inputn_test=mapminmax(apply,input_test,inputs);

%BP神经网络预测输出
an=sim(net,inputn_test);

%输出结果反归一化
BPoutput=mapminmax('reverse',an,outputps);

%网络预测结果图形
figure(1)
plot(BPoutput,':og')
hold on
plot(output_test,'-*');
legend('预测输出','期望输出')
title('BP网络预测输出','fontsize',12)
ylabel('函数输出','fontsize',12)
xlabel('样本','fontsize',12)

%网络预测误差模型
figure(2)
plot(error,'-*')
title('BP网络预测误差','fontsize',12)
ylabel('误差','fontsize',12)
xlabel('样本','fontsize',12)



