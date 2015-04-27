clear;
clc;

load RFLgroup;
y=RFLgroup(1,:);
x=[1:54];
dy=std(y);
%beta=polyfit(x,y,27);
%y=ployval(beta,x);
%beta
%plot(beta,'r*-');
for n=1:30
    [a,S]=polyfit(x,y,n);
    A{n}=a;
    da=dy*sqrt(diag(inv(S.R'*S.R)));
    DA{n}=da';
    freedom(n)=S.df;
    [ye,delta]=polyval(a,x,S);
    YE{n}=ye;
    D{n}=delta;
    chi2(n)=sum((y-ye).^2)/dy/dy;
end
Q=1-chi2cdf(chi2,freedom);
subplot(1,2,1),plot(1:30,abs(chi2-freedom),'b');
xlabel('阶次'),title('chi2与自由度');
subplot(1,2,2),plot(1:30,Q,'r',1:30,ones(1,30)*0.5);
xlabel('阶次'),title('Q与0.5线');

figure(2)
clf,plot(x,y,'b*-');axis([0,1,1,6]);hold on
errorbar(x,YE{4},D{4},'r');hold on
title('4阶');
A{4},DA{4}