function[]=LSSVR();
%% ==============清除代码窗口和工作空间===============
% clc;
% clear;

%% ==================下载数据=======================

load E:\code\gas_eas\Gas_test2\MATcode\test\data01.txt;

X01 = data01(:,2);
X02 = data01(:,3);
X03 = data01(:,4);


X1 = [X01,X02,X03];
XX1 = X1';
%XX1 = mapminmax(XX1,0,1);       %整体归一化，即整个矩阵进行归一化
XX1 = XX1';
%XX1 = X1/80;
%[XX1 A B] = svdatanorm(XX1,'rbf');
Y1 = data01(:,1);
Y1 = Y1';
%YY1 = mapminmax(Y1,0,1);
YY1 = Y1';
X11 = XX1(1:90,:);        %训练样本数据
Y11 = YY1(1:90,:);
tstX = XX1(91:120,:);tstY = YY1(91:120,:);%测试样本确定
%% ==================训练数据========================
% 数据预处理


%[Ttrain,meant, stdt]= prestd(Ttrain0);  


% 训练数据提取 



%% =====================测试数据=====================

%tstX = [7*pi:pi/180:12*pi];%测试样本确定
%tstX = tstX';
%tstY = 

%tstX = tstX';
%tstY = tstY';

G1 = [X11,Y11];     %  ,表示加列   ;表示加行  G1为训练样本
G2 = [tstX,tstY];   % G2为测试样本
G = [G1;G2];
[Ptrain,meanptrain,stdptrain] = prestd(G);
%[Ptrain,meanptrain,stdptrain] = prestd(G1);
Ptrain1 = Ptrain(1:90,1:3);
Ptrain2 = Ptrain(1:90,4);
Ttrain1 = Ptrain(91:120,1:3);
Ttrain2 = Ptrain(91:120,4);

%% =====================模型初始化=====================

type = 'function estimation'; 
kernel = 'RBF_kernel';              %线性核：'Lin_kernel';多项式核：'Poly_kernel'
% m = 1;
%for sig2 = 1:5:101;

%     n = 1;
    %for gam = 1:10:201;                 % Regularization parameter
sig2 = 4000000;
gam = 00000.3;
% Kernel parameter (bandwidth in the case of the 'RBF_kernel'
% 寻优之后的参数
% gam =  0.0869335 ;                 % Regularization parameter
% sig2 =  83.8678 ;              % Kernel parameter (bandwidth in the case of the 'RBF_kernel'


%% =====================参数寻优======================

model = initlssvm(Ptrain1,Ptrain2,type,gam,sig2,kernel,'preprocess');                 % 模型初始化
% costfun = 'crossvalidatelssvm';
% costfun_args = {10,'mse'};
% optfun = 'gridsearch';
% model = tunelssvm(model,optfun,costfun,costfun_args);   % 模型参数优化

%% ======================测试数据=======================

model = trainlssvm(model);  % 训练
Yp = simlssvm(model,Ttrain1);
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

end



