load mydata.txt 
consumption=mydata(:,2); 
log(consumption)
[gt,ct]=hpfilter(log(consumption)); 
%Done!