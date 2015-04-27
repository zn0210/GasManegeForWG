%% GAWNNδʵ��
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
a=0.45+rand(1)/4;
b1=0.45+rand(1)/4;
b2=0.45+rand(1)/4;
b3=0.45+rand(1)/4;

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
%% �Ŵ��㷨������ʼ��
maxgen=50;                         %��������������������
sizepop=30;                        %��Ⱥ��ģ
pcross=0.6;                       %�������ѡ��0��1֮��
pmutation=0.01;                    %�������ѡ��0��1֮��

%�ڵ�����
numsum=4*4+4+4*1+1;

lenchrom=ones(1,numsum);        
bound=[-3*ones(numsum,1) 3*ones(numsum,1)];    %���ݷ�Χ

%------------------------------------------------------��Ⱥ��ʼ��--------------------------------------------------------
individuals=struct('fitness',zeros(1,sizepop), 'chrom',[]);  %����Ⱥ��Ϣ����Ϊһ���ṹ��
avgfitness=[];                      %ÿһ����Ⱥ��ƽ����Ӧ��
bestfitness=[];                     %ÿһ����Ⱥ�������Ӧ��
bestchrom=[];                       %��Ӧ����õ�Ⱦɫ��
%��ʼ����Ⱥ
for i=1:sizepop
    %�������һ����Ⱥ
    individuals.chrom(i,:)=Code(lenchrom,bound);    %���루binary��grey�ı�����Ϊһ��ʵ����float�ı�����Ϊһ��ʵ��������
    x=individuals.chrom(i,:);
    %������Ӧ��
    individuals.fitness(i)=fun(x,4,4,1,net,X,Y);   %Ⱦɫ�����Ӧ��,����fun��������Ӧ�Ⱥ���
end

%����õ�Ⱦɫ��
[bestfitness bestindex]=min(individuals.fitness);
bestchrom=individuals.chrom(bestindex,:);  %��õ�Ⱦɫ��
avgfitness=sum(individuals.fitness)/sizepop; %Ⱦɫ���ƽ����Ӧ��
% ��¼ÿһ����������õ���Ӧ�Ⱥ�ƽ����Ӧ��
trace=[avgfitness bestfitness]; 
 
%% ���������ѳ�ʼ��ֵ��Ȩֵ
% ������ʼ
for i=1:maxgen
    %i
    % ѡ��,����Select����
    individuals=Select(individuals,sizepop); 
    avgfitness=sum(individuals.fitness)/sizepop;
    %���棬����Cross����
    individuals.chrom=Cross(pcross,lenchrom,individuals.chrom,sizepop,bound);
    % ���죬����Mutation����
    individuals.chrom=Mutation(pmutation,lenchrom,individuals.chrom,sizepop,i,maxgen,bound);
    
    % ������Ӧ�� 
    for j=1:sizepop
        x=individuals.chrom(j,:); %����
        individuals.fitness(j)=fun(x,inputnum,hiddennum,outputnum,net,X,Y);   
    end
    
  %�ҵ���С�������Ӧ�ȵ�Ⱦɫ�弰��������Ⱥ�е�λ��
    [newbestfitness,newbestindex]=min(individuals.fitness);
    [worestfitness,worestindex]=max(individuals.fitness);
    % ������һ�ν�������õ�Ⱦɫ��
    if bestfitness>newbestfitness
        bestfitness=newbestfitness;
        bestchrom=individuals.chrom(newbestindex,:);
    end
    individuals.chrom(worestindex,:)=bestchrom;
    individuals.fitness(worestindex)=bestfitness;
    
    avgfitness=sum(individuals.fitness)/sizepop;
    
    trace=[trace;avgfitness bestfitness]; %��¼ÿһ����������õ���Ӧ�Ⱥ�ƽ����Ӧ��

end
%% �Ŵ��㷨������� 
 figure(1)
[r c]=size(trace);
plot([1:r]',trace(:,2),'b--');
title(['��Ӧ������  ' '��ֹ������' num2str(maxgen)]);
xlabel('��������');ylabel('��Ӧ��');
legend('ƽ����Ӧ��','�����Ӧ��');
%disp('��Ӧ��                   ����');

%% �����ų�ʼ��ֵȨֵ��������Ԥ��
% %���Ŵ��㷨�Ż���BP�������ֵԤ��
x=bestchrom;
w1=x(1:inputnum*hiddennum);
B1=x(inputnum*hiddennum+1:inputnum*hiddennum+hiddennum);
w2=x(inputnum*hiddennum+hiddennum+1:inputnum*hiddennum+hiddennum+hiddennum*outputnum);
B2=x(inputnum*hiddennum+hiddennum+hiddennum*outputnum+1:inputnum*hiddennum+hiddennum+hiddennum*outputnum+outputnum);

net.iw{1,1}=reshape(w1,hiddennum,inputnum);
net.lw{2,1}=reshape(w2,outputnum,hiddennum);
net.b{1}=reshape(B1,hiddennum,1);
net.b{2}=B2;
%net.b{2}=reshape(B2,outputnum,1);

%����������ã�����������ѧϰ�ʣ�Ŀ�꣩
net.trainParam.epochs=1000;
net.trainParam.lr=0.1;
net.trainParam.goal=0.001;