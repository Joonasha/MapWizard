# T�ST� ALKAA PLOTTAUSFUNKTIO
# ==============================================================
plotlines<-function(header,area,p10,p50,p90,folder) {
  
# area: common x values for all the plotted lines
# p10,p50 and p90: y-values for the three plotted lines

# Jos haluat tiedostoon, niin ota seuraavasta rivist� kommentti pois, ja muuta polku.
  outfile <- paste(folder,"plot.jpeg",sep="")
  message(outfile)		
  jpeg(outfile,width = 800, height = 800, pointsize = 12, quality = 75)
  
# M��ritet��n plotin x ja y tick labelien paikat plotattavien pinta-alojen ja deposit m��rien perusteella 
# (muuten ne tulee rumasti). K�ytet��n n�it� my�s akseleiden rangen m��ritt�misess�.
  lg_fl_area<-floor(log10(min(area)))
  lg_ce_area<-ceiling(log10(max(area)))
  lg_fl_nocc<-floor(log10(min(p90)))
  lg_ce_nocc<-ceiling(log10(max(p10)))
  xpos<-c(1 %o% 10^(lg_fl_area:lg_ce_area))
  ypos<-c(1 %o% 10^(lg_fl_nocc:lg_ce_nocc))
 graphics.off()

# Plotataan probability 10% suora ja m��ritet��n akselien otsikot ja range
  plot(area,p10,type="l",lty=1,log="xy",col=4,main=header,xlab=expression("Tract area" ~ (km^{2})),ylab="Number of deposits",
     xaxt="n",yaxt="n",xlim=c(10^lg_fl_area,10^lg_ce_area),ylim=c(10^lg_fl_nocc,10^lg_ce_nocc))
# M��ritet��n tick labels 
  axis(1,at=xpos,labels=sprintf("%d",xpos))
  axis(2,at=ypos,labels=ypos)
# Plotataan p* viivat
  lines(area,p50,col=1)
  lines(area,p90,col=2)

#Plotataan olemassaolevat esiintym�t
#  indat<-"IndataGeneral.csv"
#  datmat<-read.csv(file=indat,header=FALSE,sep=";")
#  dimdat<-dim(datmat)
#  datarea<-as.numeric(gsub(" ","",datmat[,4],fixed=TRUE))
#  nocc<-as.numeric(datmat[,5])
#  colpts<-rep(datmat[,2])
#  message(colpts)
#  points(datarea,nocc,col=colpts,pch=16)

# Legenda
  legend ("bottomright",  c("Podiform chromite","Cyprus m. sulfide","kuroko m. sulfide","Porphyry copper","Climax porphyry Mo","Franciscan Mn","Cuban Mn","low sulfide qtz-gold","Placer gold","Tungsten vein","p10","p50","p90"),col=c(1,2,3,4,4,1,2),lty=c(NA, NA, NA,NA,NA,NA,NA,NA,NA,NA,1,1,1), pch=c(16, 16, 16,16,16,16,16,16,16,16,NA,NA, NA))
# dev.off()
}
# ==============================================================
# T�H�N P��TTYY PLOTTAUSFUNKTIO


# Seuraavassa lasketaan plotattavat arvot, ja kutsutaan yll�olevaa plottausfunktiota

# Input tiedosto, jossa PorCu density plotin data, eli 33 x 7 matriisi
#indat<-"D:/Projektit/MAP/SW/TestData/DepositDensityTool/PorCu_data.csv"
#indat<-"C:/TFS2/Muut/MapWizardi/ToolsTests/testdata/DepositDensity/IndataGeneral.csv"

plotcalculate<-function(medTons,a,b,c,t10n2,sxy,N,m_loga,m_logmedTons,std_loga,slogMedTons,min_area,max_area,NKnown,folder,headerText) {

#inpar<-c()
# PorCu parameters
#inpar[1]<--1.042 # a
#inpar[2]<-0.431 # b
#inpar[3]<-0.239 # sxy
#inpar[4]<-0.9 # probability for t-dist
#inpar[5]<-31 # n freedom for t-dist
#inpar[6]<-1.188 # std_loga
#inpar[7]<-2.615 # m_loga
#inpar[8]<-109 # N
#inpar[9]<-1000 #min area 
#inpar[10]<-1000000 #max area


# Luetaan data CSV-tiedostosta.
#indat<-"C:/TFS2/Muut/MapWizardi/ToolsTests/testdata/DepositDensity/IndataGeneral.csv"
#datmat<-read.csv(file=indat,header=FALSE,sep=";")
# Datamatriisin dimensiot
#dimdat<-dim(datmat)
# Koska datassa on string arvoja, lukee read.csv koko taulukon stringiksi.
# Pit�� muuttaa numeeriseksi ne joita k�ytet��n laskuissa, eli pinta-ala ja deposittien m��r�.
# Poistetaan my�s whitespace,jota esiintyy isoissa luvuissa (pinta-alat).
#datarea<-as.numeric(gsub(" ","",datmat[,3],fixed=TRUE))
#nocc<-as.numeric(datmat[,4])
# M��ritet��n deposit typelle arvo plotin v�rityst� varten. L�hinn� t�rke� jos plotataan se general tapaus, jossa monta eri
# esiintym�tyyppi�, ett� saadaan ne eri v�reill�. colpts vektori sis�lt�� v�rin kullekin plotattavalle pisteelle
#Deptype<-4
#colpts<-rep(Deptype,dimdat[1])

# Seuraavat rivit on niiden plotattavien viivojen laskemista varten, mutta neh�n sulla jo on koodattu.
# Lasken tossa vain alku ja loppupisteen 2-elementtisiin vektoreihin area (x-arvo) ja p* (y-arvo).
# ---------------------------------------------------------------
# t10n2<-qt(tdist,ftdist)
  #area<-seq(min(datarea),max(datarea),length.out=2)
  area<-seq(min_area,max_area,length.out=2)
  std_loga<-std_loga
  m_loga<-m_loga
  dimdat<-N
if(NKnown > 0)
{
  logN10 <-(a+b*log10(area)+c*log10(medTons))+t10n2*sxy*sqrt(1+1/dimdat[1]+(m_loga-log10(area))^2/((dimdat[1]-1)*std_loga*slogMedTons))
  logN50 <- a+b*log10(area)+c*log10(medTons)
  varN <- ((logN10-logN50)/t10n2)^2 
  logNexp <- logN50 + (varN)/2
  nEXP <- 10^(logNexp)
  logN50 <- log10(nEXP-NKnown)- varN/2
  p90<-10^(logN50-t10n2*sxy*sqrt(1+1/dimdat[1]+(m_loga-log10(area))^2/((dimdat[1]-1)*std_loga*slogMedTons)))
  p50<-10^(logN50)
  p10<-10^(logN50+t10n2*sxy*sqrt(1+1/dimdat[1]+(m_loga-log10(area))^2/((dimdat[1]-1)*std_loga*slogMedTons)))
  #message(p10)
  #message(p50)
  #message(p90)		
}
else {
  p90<-10^((a+b*log10(area)+c*log10(medTons))-t10n2*sxy*sqrt(1+1/dimdat[1]+(m_loga-log10(area))^2/((dimdat[1]-1)*std_loga*slogMedTons)))
  p50<-10^(a+b*log10(area)+c*log10(medTons))
  p10<-10^((a+b*log10(area)+c*log10(medTons))+t10n2*sxy*sqrt(1+1/dimdat[1]+(m_loga-log10(area))^2/((dimdat[1]-1)*std_loga*slogMedTons)))
  #message(p10)
  #message(p50)
  #message(p90)
}
# ---------------------------------------------------------------
  plotlines(headerText,area,p10,p50,p90,folder)
}

#plotcalculate<-function(medTons,a,b,c,t10n2,sxy,N,m_loga,m_logmedTons,std_loga,slogMedTons,min_area,max_area, NKnown, folder,headerText)
plotcalculate(0.5,-0.770,0.491,-0.227,1.290,0.348,109,3.173,-0.329,1.188,2.615,10,1000000,0,'C:/Temp/mapWizard/DepositDensity/output/General/','GENERAL')



