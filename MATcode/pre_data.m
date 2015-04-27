clear
clc;
load RFLzu;
% y=RFLzu(:,1)';
% yy=RFLzu(:,5)';
y=RFLzu(1:250,1)';
yy=RFLzu(1:250,5)';

%figure
%plot(y,'b.-','LineWidth',1);
%xlabel('ʱ��');
%ylabel('ú������ʵ��ֵ');

sd=smoothts(y,'g',30);%���ڿ��Ϊ30����׼��ΪĬ��ֵ0.65
sdd=smoothts(yy,'g',30);
sd1=smoothts(y,'g',50,10);%���ڿ�50����׼��Ϊ10
figure
plot(y,'b.-');
hold on
plot(sd,'gs-','markerfacecolor','g','markersize',5);
plot(sd1,'r^-','markerfacecolor','r','markersize',5);
xlabel('Time/min','fontsize',10); ylabel('Gaussian window','fontsize',10);
title('��˹����������ƽ������');
legend('ԭʼ��������','ƽ������(�����30,��׼��0.65)',...
   'ƽ������(�����50,��׼��10)');
%title('Smoothing the data by Gaussian window','fontsize',10);
% le=legend('Original data','Smoothing(window width 30,SD 0.65)',...
%     'Smoothing(window width 50,SD 10)');
% set(le,'fontsize',10);
%��������
% A=[sd;sdd]';
% RFLzusd=reshape(A,945,2);
% save RFLzusd;
%save sdd RFLgroup(:,6);