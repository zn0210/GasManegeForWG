clear
clc;
load RFLzu;
% y=RFLzu(:,1)';
% yy=RFLzu(:,5)';
y=RFLzu(1:250,1)';
yy=RFLzu(1:250,5)';

%figure
%plot(y,'b.-','LineWidth',1);
%xlabel('时间');
%ylabel('煤气流量实际值');

sd=smoothts(y,'g',30);%窗口宽度为30，标准差为默认值0.65
sdd=smoothts(yy,'g',30);
sd1=smoothts(y,'g',50,10);%窗口宽50，标准差为10
figure
plot(y,'b.-');
hold on
plot(sd,'gs-','markerfacecolor','g','markersize',5);
plot(sd1,'r^-','markerfacecolor','r','markersize',5);
xlabel('Time/min','fontsize',10); ylabel('Gaussian window','fontsize',10);
title('高斯窗对数据做平滑处理');
legend('原始数据曲线','平滑处理(窗宽度30,标准差0.65)',...
   '平滑处理(窗宽度50,标准差10)');
%title('Smoothing the data by Gaussian window','fontsize',10);
% le=legend('Original data','Smoothing(window width 30,SD 0.65)',...
%     'Smoothing(window width 50,SD 10)');
% set(le,'fontsize',10);
%保存数据
% A=[sd;sdd]';
% RFLzusd=reshape(A,945,2);
% save RFLzusd;
%save sdd RFLgroup(:,6);