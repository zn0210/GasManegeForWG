function fitval = fitcal(pm,net,indim,hiddennum,outdim,D,Ptrain,Ttrain,minAllSamOut,maxAllSamOut)
[x,y,z]=size(pm);
for i=1:x
    for j=1:hiddennum
        x2iw(j,:)=pm(i,((j-1)*indim+1):j*indim,z);
    end
    for k=1:outdim
        x2lw(k,:)=pm(i,(indim*hiddennum+1):(indim*hiddennum+hiddennum),z);
    end
    x2b=pm(i,((indim+1)*hiddennum+1):D,z);
    x2b1=x2b(1:hiddennum).';
    x2b2=x2b(hiddennum+1:hiddennum+outdim).';
    net.IW{1,1}=x2iw;  % input weight matrix
    net.LW{2,1}=x2lw;  % layer weight matrix 
    net.b{1}=x2b1;     %
    net.b{2}=x2b2;
    error=sim(net,Ptrain)-Ttrain;
    fitval(i,1,z)=mse(error); %返回值 每一个个体的适应值
end