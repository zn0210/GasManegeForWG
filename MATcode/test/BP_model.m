
%��ջ�������
% clc
% clear

%%����ѡ��͹�һ��
%���������������
% load data input output
%  load data input output


%���ѡ��1900��ѵ�����ݺ�100��Ԥ������

k=rand(1,2000);
[m,n]=sort(k);
input_train=input(n(1:1900),:)';
output_train=output(n(1:1900),:)';
input_test=input(n(1901:2000),:)';
output_test=output(n(1901:2000),:)';

%ѵ�����ݹ�һ��
[inputn,inputs]=mapminmax(input_train);
[outputn,outputs]=mapminmax(output_train);

%%����ѵ��
%BP�����繹��
net=newff(inputn,outputn,5);

%����������ã�����������ѧϰ�ʣ�Ŀ�꣩
net.trainParam.epochs=100;
net.trainParam.lr=0.1;
net.trainParam.goal=0.00004;

%BP������ѵ��
net=train(net,inputn,outputn);

%%BP������Ԥ��
%Ԥ�����ݹ�һ��
inputn_test=mapminmax(apply,input_test,inputs);

%BP������Ԥ�����
an=sim(net,inputn_test);

%����������һ��
BPoutput=mapminmax('reverse',an,outputps);

%����Ԥ����ͼ��
figure(1)
plot(BPoutput,':og')
hold on
plot(output_test,'-*');
legend('Ԥ�����','�������')
title('BP����Ԥ�����','fontsize',12)
ylabel('�������','fontsize',12)
xlabel('����','fontsize',12)

%����Ԥ�����ģ��
figure(2)
plot(error,'-*')
title('BP����Ԥ�����','fontsize',12)
ylabel('���','fontsize',12)
xlabel('����','fontsize',12)



