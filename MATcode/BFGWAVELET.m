clear
clc
% function bw=BFGWAVELET()
%% С���������ʱ������Ԥ��
tic;
t1=clock;   %��ȡ��ǰʱ��
%��������
load BFGTpre;
B=BFGTpre;

[m,n]=size(B);
for i=1:30:length(B)
    C(:,(i-1)/30+1)=B(i:i+29,:);    %���30��ȡ��
end

D=C';
for i=1:36
    p(i,:)=[D(i,:),D(i+1,:),D(i+2,:),D(i+3,:)];
end
%ѵ�������������
X=p(1:35,:)';
Y=D(2:36,:)';
%ѵ�����ݹ�һ��
[inputn,inputps]=mapminmax(X);
[outputn,outputps]=mapminmax(Y);

input=inputn';
output=outputn';

%����ṹ��ʼ�����õ�ǰ��ǰ120������Ԥ���30������
M=120;
N=30;
n=3;

%Ȩֵ�Ͳ���ѧϰ��
lr1=0.01;
lr2=0.001;
maxgen=100;%�����������

%����Ȩֵ��ʼ��
Wjk=randn(n,M);
%Wjk_1=Wjk;Wjk_2=Wjk_1;
Wij=randn(N,n);
%Wij_1=Wij;Wij_2=Wij_1;
%% ����������a��ʼ����[0,1]֮�䣬��[0,0.5]��(0.5,1)�����ϵ�a���ӳ�䵽����[0,1]��(1,5];
 %  ��ƽ������b��ʼ����[-1,1]֮�䣬����10��ʹ������Ϊ[-10,10];
a=rand(1,n);
ind1=find(a>=0&a<=0.5);
indnum1=length(ind1);
a(1,ind1)=0+(1-0)*rand(1,indnum1);
ind2=find(a>0.5&a<=1);
indnum2=length(ind2);
a(1,ind2)=1+(5-1)*rand(1,indnum2);
a_1=a;a_2=a_1;
b=unifrnd(-1,1,1,n);
b_1=b*20;b_2=b_1;
%%
%�ڵ��ʼ��
y=zeros(1,N);
net=zeros(1,n);
net_ab=zeros(1,n);

%Ȩֵѧϰ������ʼ��
d_Wjk=zeros(n,M);
d_Wij=zeros(N,n);
d_a=zeros(1,n);
d_b=zeros(1,n);

%% ����ѵ��
for i=1:maxgen
    
    %����ۼ�
    error(i)=0;
    
    % ѭ��ѵ��
    for kk=1:size(input,1)
        x=input(kk,:);
        yqw=output(kk,:);
   
        for j=1:n
            for k=1:M
                net(j)=net(j)+Wjk(j,k)*x(k);
                net_ab(j)=(net(j)-b(j))/a(j);
            end
            temp=mymorlet(net_ab(j));
            for k=1:N
                y=y+Wij(k,j)*temp;   %С������
            end
        end
        
        %��������
        error(i)=error(i)+sum(abs(yqw-y));
        
        %Ȩֵ����
        for j=1:n
            %����d_Wij
            temp=mymorlet(net_ab(j));
            for k=1:N
                d_Wij(k,j)=d_Wij(k,j)-(yqw(k)-y(k))*temp;
            end
            %����d_Wjk
            temp=d_mymorlet(net_ab(j));
            for k=1:M
                for l=1:N
                    d_Wjk(j,k)=d_Wjk(j,k)+(yqw(l)-y(l))*Wij(l,j) ;
                end
                d_Wjk(j,k)=-d_Wjk(j,k)*temp*x(k)/a(j);
            end
            %����d_b
            for k=1:N
                d_b(j)=d_b(j)+(yqw(k)-y(k))*Wij(k,j);
            end
            d_b(j)=d_b(j)*temp/a(j);
            %����d_a
            for k=1:N
                d_a(j)=d_a(j)+(yqw(k)-y(k))*Wij(k,j);
            end
            d_a(j)=d_a(j)*temp*((net(j)-b(j))/b(j))/a(j);
        end
        
        %Ȩֵ��������      
%         Wij=Wij-lr1*d_Wij;%�ݶ�ѧϰ�㷨
%         Wjk=Wjk-lr1*d_Wjk;
%         b=b-lr2*d_b;
%         a=a-lr2*d_a;
        h=0.3;
        Wjk0=reshape(Wjk,1,3*120);
        Wij0=reshape(Wij,1,30*3);
        for mm=1:89
        Wij=Wij-lr1*d_Wij+h*(Wij0(1,mm+1)-Wij0(1,mm));% ���Ӷ������������ѧϰ����
        end
        for nn=1:359
        Wjk=Wjk-lr1*d_Wjk+h*(Wjk0(1,nn+1)-Wjk0(1,nn));
        end
        b=b-lr2*d_b+h*(b_1-b_2);
        a=a-lr2*d_a+h*(a_1-a_2);
        end
  
        d_Wjk=zeros(n,M);
        d_Wij=zeros(N,n);
        d_a=zeros(1,n);
        d_b=zeros(1,n);

        y=zeros(1,N);
        net=zeros(1,n);
        net_ab=zeros(1,n);
        
%         Wjk_1=Wjk;Wjk_2=Wjk_1;
%         Wij_1=Wij;Wij_2=Wij_1;
%         a_1=a;a_2=a_1;
%         b_1=b;b_2=b_1;
end
load BWinput_testpre;
load BWoutput_test;
%Ԥ�������һ��
x=mapminmax('apply',BWinput_testpre,inputps);
x=x';
%����Ԥ��
 for j=1:1:n
     for k=1:1:M
         net(j)=net(j)+Wjk(j,k)*x(1);
         net_ab(j)=(net(j)-b(j))/a(j);
     end
     temp=mymorlet(net_ab(j));
     for k=1:N
         y(k)=y(k)+Wij(k,j)*temp ; 
     end
 end
%yuce(i)=y(k);
%y=zeros(1,N);
%net=zeros(1,n);
%net_ab=zeros(1,n);
%Ԥ���������һ��
ynn=mapminmax('reverse',y(k),outputps);
E=ynn-BWoutput_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);
RE=E./BWoutput_test  %������
disp(['��������ʱ�䣺',num2str(etime(clock,t1))]);
% fid=fopen('bwl.txt','wt');
% fidd=fopen('bwlo.txt','wt');
% fprintf(fid,'%g\n',ynn);
% fprintf(fidd,'%g\n',BWoutput_test);
% fclose(fid);
% fclose(fidd);

% �������
figure(1)
plot(error,'-');
title('�����������','fontsize',12);
xlabel('��������');
ylabel('Ԥ������ۻ�');

figure(2)
plot(ynn,'s-r','linewidth',1,'markerfacecolor','r','markersize',5);
hold on
plot(BWoutput_test,'o-b','markerfacecolor','b','markersize',5);
title('�����Ľ���С���������¯ú��������Ԥ��','fontsize',10);
legend('ú������Ԥ��ֵ','ú������ʵ��ֵ','fontsize',10);
xlabel('ʱ���','fontsize',10);
ylabel('ú������','fontsize',10);

x=0:0.01:30;
y=0;
figure(3)
plot(x,y,'-b','linewidth',3);
hold on
plot(RE,'s-r','linewidth',1,'markerfacecolor','r');
title('������ͼ','fontsize',10);
xlabel('ʱ��/min','fontsize',10);
ylabel('������','fontsize',10);
% bw=ynn;

