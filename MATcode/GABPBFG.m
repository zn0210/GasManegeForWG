%%��GABP����Ԥ��BFGЧ�����ã�����
clc
clear
%% ����ṹ����
%��ȡ����
load BFGTpre;
BFGWL=BFGTpre;

B=BFGWL;
[m,n]=size(B);
for i=1:30:length(B)
    C(:,(i-1)/30+1)=B(i:i+29,:);
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

input=inputn;
output=outputn;

%ѵ����������
X=input;
%ѵ���������
Y=output;

%����ṹ��ʼ�����õ�ǰ��ǰ120������Ԥ���30������
inputnum=120;
outputnum=30;
hiddennum=3;

%BP�����繹��
net=newff(X,Y,hiddennum);

%% �Ŵ��㷨������ʼ��
maxgen=10;                         %��������������������
sizepop=10;                        %��Ⱥ��ģ
pcross=0.3;                       %�������ѡ��0��1֮��
pmutation=0.1;                    %�������ѡ��0��1֮��

%�ڵ�����
numsum=inputnum*hiddennum+hiddennum+hiddennum*outputnum+outputnum;

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
    individuals.fitness(i)=fun(x,inputnum,hiddennum,outputnum,net,X,Y);   %Ⱦɫ�����Ӧ��,����fun��������Ӧ�Ⱥ���
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
%net.b{2}=B2;
net.b{2}=reshape(B2,outputnum,1);

%����������ã�����������ѧϰ�ʣ�Ŀ�꣩
net.trainParam.epochs=1000;
net.trainParam.lr=0.1;
net.trainParam.goal=0.001;

%BP������ѵ��
net=train(net,X,Y);

load BWinput_test;
load BWoutput_test;
%Ԥ�������һ��
bx=mapminmax('apply',BWinput_test,inputps);

%BP������Ԥ�����
an=sim(net,bx);
%yuce(i)=y(k);
%y=zeros(1,N);
%net=zeros(1,n);
%net_ab=zeros(1,n);
%Ԥ���������һ��
ynn=mapminmax('reverse',an,outputps);
E=ynn-BWoutput_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);

%����Ԥ����ͼ��
figure(2)
plot(ynn,'*-r')
hold on
plot(BWoutput_test,'.-b');
legend('Ԥ�����','�������')
title('GABP����Ԥ�����','fontsize',12)
ylabel('ú������','fontsize',12)
xlabel('ʱ��/m','fontsize',12)

%����Ԥ�����ͼ��
figure(3)
bar(E,'b')
title('GABP����Ԥ�����','fontsize',12)
ylabel('���','fontsize',12)
xlabel('ʱ��/m','fontsize',12)
