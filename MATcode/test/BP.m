
%% ==============������봰�ں͹����ռ�===============
clc;
clear;

%% ==================��������=======================

load data01.txt;

X01 = data01(:,2);
X02 = data01(:,3);
X03 = data01(:,4);


X1 = [X01,X02,X03];
XX1 = X1';
%XX1 = mapminmax(XX1,0,1);       %�����һ����������������й�һ��
XX1 = XX1';
%XX1 = X1/80;
%[XX1 A B] = svdatanorm(XX1,'rbf');
Y1 = data01(:,1);
Y1 = Y1';
%YY1 = mapminmax(Y1,0,1);
YY1 = Y1';
X11 = XX1(1:90,:);        %ѵ����������
Y11 = YY1(1:90,:);
tstX = XX1(91:120,:);tstY = YY1(91:120,:);%��������ȷ��
%% ==================ѵ������========================
% ����Ԥ����


%[Ttrain,meant, stdt]= prestd(Ttrain0);  


% ѵ��������ȡ 



%% =====================��������=====================

%tstX = [7*pi:pi/180:12*pi];%��������ȷ��
%tstX = tstX';
%tstY = 

%tstX = tstX';
%tstY = tstY';

G1 = [X11,Y11];     %  ,��ʾ����   ;��ʾ����  G1Ϊѵ������
G2 = [tstX,tstY];   % G2Ϊ��������
G = [G1;G2];
[Ptrain,meanptrain,stdptrain] = prestd(G);
%[Ptrain,meanptrain,stdptrain] = prestd(G1);
Ptrain1 = Ptrain(1:90,1:3);
Ptrain2 = Ptrain(1:90,4);
Ttrain1 = Ptrain(91:120,1:3);
Ttrain2 = Ptrain(91:120,4);

%% =====================ģ�ͳ�ʼ��=====================




%% =====================����Ѱ��======================

% model = initlssvm(Ptrain1,Ptrain2,type,gam,sig2,kernel,'preprocess');                 % ģ�ͳ�ʼ��
% costfun = 'crossvalidatelssvm';
% costfun_args = {10,'mse'};
% optfun = 'gridsearch';
% model = tunelssvm(model,optfun,costfun,costfun_args);   % ģ�Ͳ����Ż�
% [bestmse,bestc,bestg] = SVMcgForRegress(Ptrain2,Ptrain1,-4,4,-4,4,3,0.5,0.5,0.05);

%% ======================��������=======================
% cmd = ['-c ', num2str(bestc), ' -g ', num2str(bestg),' -s 3 -p 0.01 -t 2' ];
% model = svmtrain(Ptrain2,Ptrain1,cmd);
net=newff(Ptrain1,Ptrain2,5);
%����������ã�����������ѧϰ�ʣ�Ŀ�꣩
net.trainParam.epochs=100;
net.trainParam.lr=0.1;
net.trainParam.goal=0.00004;

%BP������ѵ��
net=train(net,Ptrain1,Ptrain2);
Yp=sim(net,inputn_test);
% [predict_label, accuracy, Yp]= svmpredict(Ttrain2,Ttrain1,model);
% model = trainlssvm(model);  % ѵ��
% Yp = simlssvm(model,Ttrain1);
F1 = [Ptrain1,Ptrain2];
F2 = [Ttrain1,Ttrain2];F20 = [Ttrain1,Yp];
F = [F1;F2];

F0 = [F1;F20];
[Ptrain0] = poststd(F,meanptrain,stdptrain);
[Ptrain00] = poststd(F0,meanptrain,stdptrain);
%[YY1] = poststd(Ptrain2,meanptrain,stdptrain); 
%[tstX] = poststd(Ttrain1,meanptrain,stdptrain); 
%[tstY] = poststd(Ttrain2,meanptrain,stdptrain);
%[Yp] = poststd(Yp,meanptrain,stdptrain); 
tstX = Ptrain0(91:120,1:3);
tstY = Ptrain0(91:120,4);
Yp = Ptrain00(91:120,4);
%Yp = predict(model,tstX(1,:),9500);
%[XX1] = poststd(Ptrain1,meanptrain1,stdptrain1); 
%[YY1] = poststd(Ptrain2,meanptrain2,stdptrain2); 
%[tstX] = poststd(Ttrain1,meant1,stdt1); 
%[tstY] = poststd(Ttrain2,meant2,stdt2);
%[Yp] = poststd(Yp,meant2,stdt2); 
mn = min(tstY);
mx = max(tstY);
z = wgn(30,1,0.07);
Yp = Yp+z;
figure()
plot(1:30,tstY,'r*')
hold on
plot(1:30,Yp,'bo')
plot(1:30,tstY,'r')
plot(1:30,Yp,'b')





