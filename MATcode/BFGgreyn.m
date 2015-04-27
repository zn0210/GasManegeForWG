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
a=0.55+rand(1)/4;
b1=0.40+rand(1)/4;
b2=0.40+rand(1)/4;
b3=0.40+rand(1)/4;

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
%数据测试
X_test=BFGgrey(801:830,:)';
Y_test=BFGgrey(801:830,1)';
[n1,m1]=size(X_test);
[input_test,input_testps]=mapminmax(X_test);
[output_test,output_testps]=mapminmax(Y_test);
z=input_test';
for i=1:30
    t=i;
    LB_b=1/(1+exp(-w11*t));   %LB层输出
    LC_c1=LB_b*w21;           %LC层输出
    LC_c2=z(i,2)*LB_b*w22;    %LC层输出
    LC_c3=z(i,3)*LB_b*w23;    %LC层输出
    LC_c4=z(i,4)*LB_b*w24;
    LD_d=w31*LC_c1+w32*LC_c2+w33*LC_c3+w34*LC_c4;    %LD层输出
    theta=(1+exp(-w11*t))*(w22*z(i,2)/2+w23*z(i,3)/2+w24*z(i,4)/2-z(1,1));   %阀值
    zm=LD_d-theta;   %网络输出值
    zc(i)=zm;
    %计算误差
end
Greyoutput=mapminmax('reverse',zc,output_testps);
Er=Greyoutput-Y_test;
MSE=mse(Er);
SSE=sse(Er);
MAE=mae(Er);
RE=Er./Y_test  %相对误差
REE=sum(abs(RE))/30
disp(['程序运行时间：',num2str(etime(clock,t1))]);

figure(1)
plot(E)
title('误差随进化次数变化趋势');
xlabel('进化次数');
ylabel('误差');

figure(2)
plot(Greyoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5);
hold on
plot(Y_test','o-b','markerfacecolor','b','markersize',5);
title('灰色神经网络预测高炉煤气流量','fontsize',8);
legend('网络预测值','实际输出值','fontsize',8)
xlabel('时间','fontsize',8)
ylabel('BFG煤气量','fontsize',8)

figure(3)
line([0 30],[0 0],'linewidth',2);
hold on
plot(RE,'s-r','linewidth',1,'markerfacecolor','r');
title('预测误差统计图','fontsize',8);
xlabel('时间','fontsize',8);
ylabel('误差','fontsize',8);
box on