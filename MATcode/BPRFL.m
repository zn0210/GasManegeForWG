clc
clear
%% ����ṹ����
t1=clock;
%��ȡ����
load RFLzus
%���ѡȡ500��������Ϊѵ�����ݺ�50��������ΪԤ������
Train=RFLzus(1:800,:)';
Test=RFLzus(821:850,:)';

%ѵ�����ݹ�һ��
[inputn,inputps]=mapminmax(Train);

%�����ۼ�
[n1,m1]=size(inputn);
for i=1:m1
   x(1,i)=sum(inputn(1,1:i));
   x(2,i)=sum(inputn(2,1:i));
   x(3,i)=sum(inputn(3,1:i));
   x(4,i)=sum(inputn(4,1:i));
   x(5,i)=sum(inputn(5,1:i));
end
a=x';
%ѵ����������
X=a(1:800,1:4);
%ѵ���������
Y=a(1:800,5);


%BP�����繹��
net=newff(X',Y',3);
%����������ã�����������ѧϰ�ʣ�Ŀ�꣩
net.trainParam.epochs=1000;
net.trainParam.lr=0.1;
net.trainParam.goal=0.001;

%BP������ѵ��
net=train(net,X',Y');

%ѡȡ501��550��Ϊ�������ݵ����룬501��550��Ϊ���
input_test=Test(1:4,1:30);
output_test=Test(5,1:30);
%�������ݹ�һ��
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
%BP������Ԥ�����
an=sim(net,zz);
ys=an;
for j=30:-1:2
    ys(j)=an(j)-an(j-1);
end

%Ԥ��������ݷ���һ��
BPoutput=mapminmax('reverse',ys',output_testzps);
E=BPoutput'-output_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);
RE=E./output_test  %������
disp(['��������ʱ�䣺',num2str(etime(clock,t1))]);
%RMSE=sqrtm(MSE);%���������
%NMSE=MSE/SSE;%���滯�������

%����Ԥ����ͼ��
figure(1)
plot(BPoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5)
hold on
plot(output_test,'o-b','markerfacecolor','b','markersize',5);
legend('BPԤ�����','�������')
title('BP����Ԥ�����','fontsize',10)
ylabel('ú������','fontsize',10)
xlabel('ʱ��/m','fontsize',10)
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
title('BP����Ԥ��������','fontsize',10)
ylabel('���','fontsize',10)
xlabel('ʱ��/m','fontsize',10)
% plot(RE,'s-r','linewidth',1,'markerfacecolor','r')
% hold on
% line([0,30],[0,0])
% title('The prediction relative error of BP','fontsize',10)
% ylabel('Relative error','fontsize',10)
% xlabel('Time/min','fontsize',10)