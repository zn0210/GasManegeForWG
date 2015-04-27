clc
clear

load BFGTpre;
B=BFGTpre;
B1000=B(1:1000);
B200=B(1001:1200);
k = xlsread( 'F:\321.xlsx','A1:A200');
k2=k/200;
O200=B200.*k2;
BFGTpreS=[B1000;O200];
save BFGTpreS;

BWinput_testpreS=BFGTpreS(951:1070);
save BWinput_testpreS;
BWoutput_testS=BFGTpreS(1071:1100);
save BWoutput_testS;