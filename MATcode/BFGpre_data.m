clear
clc
%��������
load BFGgrey;
load BWinput_test;
BFGPRE=BFGgrey(:,2);
[m,n]=size(BFGPRE);
%% ����С����BFGʱ�����н���ȱʡֵ���룬ѹ��
%thr��ֵ��sorh ��Ӳ��ֵ��ѡ��
[thr,sorh,keepapp]=ddencmp('den','wv',BFGPRE);
[thr1,sorh1,keepapp1]=ddencmp('den','wv',BWinput_test);
subplot(211);
plot(BFGPRE);
title('BFGԭʼ����');
xd=wdencmp('lvd',BFGPRE,'db3',1,thr,sorh);% lvd ÿһ���ò�ͬ����ֵ
xt=wdencmp('lvd',BWinput_test,'db3',1,thr,sorh);
subplot(212);
plot(xd);
title('BFG�ع�����');
e=xd-BFGPRE;
err=norm(BFGPRE-xd);
figure(2)
plot(e,'g');
BFGTpre=reshape(xd,m,1);
save BFGTpre;
BWinput_testpre=reshape(xt,120,1);
save BWinput_testpre;

%�ú��ӷ�Ԥ��������
% sd=smoothts(BFGPRE,'b',2);%���ڿ��Ϊ30
% sd1=smoothts(BFGPRE,'b',20);%���ڿ�100
% figure
% plot(BFGPRE,'b.-');
% hold on
% plot(sd,'r.-');
% plot(sd1,'g.-');
% xlabel('time'); ylabel('Gaussian window');
% legend('ԭʼ��������','ƽ������(���5,)',...
%     'ƽ������(���50)');
%��������
% BFGb=reshape(sd,200,1);
% save BFGb;