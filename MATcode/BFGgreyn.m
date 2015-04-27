clc
clear
t1=clock;
%��������
load BFGgrey;
%ͨ����һ�У��ڶ���,��������Ԥ�����һ��ֵ
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

%���������ʼ��
a=0.55+rand(1)/4;
b1=0.40+rand(1)/4;
b2=0.40+rand(1)/4;
b3=0.40+rand(1)/4;

%ѧϰ����
u1=0.1;
u2=0.1;
u3=0.1;

%����Ȩֵ��ʽȡȨֵ
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

%��¼���
E=zeros(1,100);
%����ѭ��
for j=1:100
%ѭ������
for i=1:m
    t=i;
    LB_b=1/(1+exp(-w11*t));   %LB�����
    LC_c1=LB_b*w21;           %LC�����
    LC_c2=y(i,2)*LB_b*w22;    %LC�����
    LC_c3=y(i,3)*LB_b*w23;    %LC�����
    LC_c4=y(i,4)*LB_b*w24;
    LD_d=w31*LC_c1+w32*LC_c2+w33*LC_c3+w34*LC_c4;    %LD�����
    theta=(1+exp(-w11*t))*(w22*y(i,2)/2+w23*y(i,3)/2+w24*y(i,4)/2-y(1,1));   %��ֵ
    ym=LD_d-theta;   %�������ֵ
    yc(i)=ym;
    %�������
    error=ym-y(i,1);
    E(j)=E(j)+error;
   % Ȩֵ����
    error1=error*(1+exp(-w11*t));
    error2=error*(1+exp(-w11*t));
    error3=error*(1+exp(-w11*t));
    error4=error*(1+exp(-w11*t));
    error5=(1/(1+exp(-w11*t)))*(1-1/(1+exp(-w11*t)))*(w21*error1+w22*error2+w23*error3+w24*error4);
    
    %�޸�Ȩֵ
    w22=w22-u1*error2*LB_b;
    w23=w23-u2*error3*LB_b;
    w24=w24-u3*error4*LB_b;
    w11=w11+a*t*error5;
end
end
%���ݲ���
X_test=BFGgrey(801:830,:)';
Y_test=BFGgrey(801:830,1)';
[n1,m1]=size(X_test);
[input_test,input_testps]=mapminmax(X_test);
[output_test,output_testps]=mapminmax(Y_test);
z=input_test';
for i=1:30
    t=i;
    LB_b=1/(1+exp(-w11*t));   %LB�����
    LC_c1=LB_b*w21;           %LC�����
    LC_c2=z(i,2)*LB_b*w22;    %LC�����
    LC_c3=z(i,3)*LB_b*w23;    %LC�����
    LC_c4=z(i,4)*LB_b*w24;
    LD_d=w31*LC_c1+w32*LC_c2+w33*LC_c3+w34*LC_c4;    %LD�����
    theta=(1+exp(-w11*t))*(w22*z(i,2)/2+w23*z(i,3)/2+w24*z(i,4)/2-z(1,1));   %��ֵ
    zm=LD_d-theta;   %�������ֵ
    zc(i)=zm;
    %�������
end
Greyoutput=mapminmax('reverse',zc,output_testps);
Er=Greyoutput-Y_test;
MSE=mse(Er);
SSE=sse(Er);
MAE=mae(Er);
RE=Er./Y_test  %������
REE=sum(abs(RE))/30
disp(['��������ʱ�䣺',num2str(etime(clock,t1))]);

figure(1)
plot(E)
title('�������������仯����');
xlabel('��������');
ylabel('���');

figure(2)
plot(Greyoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5);
hold on
plot(Y_test','o-b','markerfacecolor','b','markersize',5);
title('��ɫ������Ԥ���¯ú������','fontsize',8);
legend('����Ԥ��ֵ','ʵ�����ֵ','fontsize',8)
xlabel('ʱ��','fontsize',8)
ylabel('BFGú����','fontsize',8)

figure(3)
line([0 30],[0 0],'linewidth',2);
hold on
plot(RE,'s-r','linewidth',1,'markerfacecolor','r');
title('Ԥ�����ͳ��ͼ','fontsize',8);
xlabel('ʱ��','fontsize',8);
ylabel('���','fontsize',8);
box on