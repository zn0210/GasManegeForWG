clc
clear
%% ����ṹ����
t1=clock;
%��ȡ����
load RFLzus

%�ڵ����
inputnum=4;
hiddennum=5;
outputnum=1;

%���ѡȡ1410��������Ϊѵ�����ݺ�30��������ΪԤ������
Train_in=RFLzus(1:800,1:4)';
Train_out=RFLzus(1:800,5)';

%ѵ�����ݹ�һ��
[inputn,inputps]=mapminmax(Train_in);
[outputn,outputps]=mapminmax(Train_out);

%ѵ����������
X=inputn;
%ѵ���������
Y=outputn;

%BP�����繹��
net=newff(X,Y,hiddennum);

%% �Ŵ��㷨������ʼ��
maxgen=30;                         %��������������������
sizepop=30;                        %��Ⱥ��ģ
pcross=0.6;                       %�������ѡ��0��1֮��
pmutation=0.01;                    %�������ѡ��0��1֮��

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
net.b{2}=B2;
%net.b{2}=reshape(B2,outputnum,1);

%����������ã�����������ѧϰ�ʣ�Ŀ�꣩
net.trainParam.epochs=1000;
net.trainParam.lr=0.1;
net.trainParam.goal=0.001;

%BP������ѵ��
net=train(net,X,Y);

%ѡȡ1231��1410��Ϊ�������ݵ����룬1411��1440��Ϊ���
input_test=RFLzus(821:850,1:4)';
output_test=RFLzus(821:850,5)';

%�������ݹ�һ��
[inputn_test,input_testzps]=mapminmax(input_test);
[outputn_test,output_testzps]=mapminmax(output_test);

%BP������Ԥ�����
an=sim(net,inputn_test);

%Ԥ��������ݷ���һ��
GABPoutput=mapminmax('reverse',an,output_testzps);
%BPoutput(1)=340;
E=GABPoutput-output_test;
MSE=mse(E);
SSE=sse(E);
MAE=mae(E);
RE=E./output_test  %������
disp(['��������ʱ�䣺',num2str(etime(clock,t1))]);

%����Ԥ����ͼ��
figure(2)
plot(GABPoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5)
hold on
plot(output_test,'o-b','markerfacecolor','b','markersize',5);
legend('GABPԤ�����','�������')
title('GABP����Ԥ�����','fontsize',10)
ylabel('ú������','fontsize',10)
xlabel('ʱ��/m','fontsize',10)
% plot(GABPoutput,'s-r','linewidth',1,'markerfacecolor','r','markersize',5);
% hold on;
% plot(output_test,'o-b','markerfacecolor','b','markersize',5);
% legend('The result of GABP','Expected output')
% title('The prediction of GABP','fontsize',10)
% ylabel('Gas amount/km3','fontsize',10)
% xlabel('Time/min','fontsize',10)


%����Ԥ�����ͼ��
figure(3)
line([0,30],[0,0])
hold on
plot(RE,'s-r','linewidth',1,'markerfacecolor','r')
title('GABPԤ��������','fontsize',10)
ylabel('���','fontsize',10)
xlabel('ʱ��/m','fontsize',10)
box on
% plot(RE,'s-r','linewidth',1,'markerfacecolor','r')
% hold on
% line([0,30],[0,0])
% title('The prediction relative error of GABP','fontsize',10)
% ylabel('Relative error','fontsize',10)
% xlabel('Time/min','fontsize',10)
