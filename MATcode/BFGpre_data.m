clear
clc
%下载数据
load BFGgrey;
load BWinput_test;
BFGPRE=BFGgrey(:,2);
[m,n]=size(BFGPRE);
%% 利用小波对BFG时间序列进行缺省值消噪，压缩
%thr阈值，sorh 软、硬阈值的选择
[thr,sorh,keepapp]=ddencmp('den','wv',BFGPRE);
[thr1,sorh1,keepapp1]=ddencmp('den','wv',BWinput_test);
subplot(211);
plot(BFGPRE);
title('BFG原始数据');
xd=wdencmp('lvd',BFGPRE,'db3',1,thr,sorh);% lvd 每一层用不同的阈值
xt=wdencmp('lvd',BWinput_test,'db3',1,thr,sorh);
subplot(212);
plot(xd);
title('BFG重构数据');
e=xd-BFGPRE;
err=norm(BFGPRE-xd);
figure(2)
plot(e,'g');
BFGTpre=reshape(xd,m,1);
save BFGTpre;
BWinput_testpre=reshape(xt,120,1);
save BWinput_testpre;

%用盒子法预处理数据
% sd=smoothts(BFGPRE,'b',2);%窗口宽度为30
% sd1=smoothts(BFGPRE,'b',20);%窗口宽100
% figure
% plot(BFGPRE,'b.-');
% hold on
% plot(sd,'r.-');
% plot(sd1,'g.-');
% xlabel('time'); ylabel('Gaussian window');
% legend('原始数据曲线','平滑曲线(宽度5,)',...
%     '平滑曲线(宽度50)');
%保存数据
% BFGb=reshape(sd,200,1);
% save BFGb;