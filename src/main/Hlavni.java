/*
 * 	This is Test:MS-DOS program. It is basic Ask/Answer test program.
 * 
 * 	Copyright © 2016 Štìpán Venclík
 * 
 * 	This file is part of Test:MS-DOS program.
 * 	
 * 	Test:MS-DOS is free software: you can redistribute it and/or modify
 * 	it under the terms of the GNU General Public License as published by
 * 	the Free Software Foundation, either version 3 of the License, or
 * 	(at your option) any later version.
 * 
 * 	Test:MS-DOS is distributed in the hope that it will be useful, 
 * 	but WITHOUT ANY WARRANTY; without even the implied warranty of
 * 	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * 	GNU General Public License for more details.
 * 
 * 	You should have received a copy of the GNU General Public License
 * 	along with Test:MS-DOS.  If not, see <http://www.gnu.org/licenses/>.
 * */

package main;

import javax.xml.parsers.*;
import org.w3c.dom.*;
import java.io.*;
import java.util.Random;

public class Hlavni {
	// CONFIG
	public static int MAX_BODU;
	public static int POCET_SKUPIN;
	public static double VERZE;
	public static int ROK;
	// /CONFIG
	
	static Menu Menu;
	static Okno Q;
	static String s;
	static Document doc;
	static DocumentBuilderFactory dbf;
	static DocumentBuilder builder;
	static final String SOUBOR = "data/config.xml";
	static File f;
	static String o1;
	static String o2;
	static String cesta;
	static Node root;
	static Node Qroot;
	static Node Croot;
	
	
	public static void main(String[] args) {
		Menu = new Menu(); 
		Menu.setVisible(true);
		//xml
		f = new File(SOUBOR);
		if(f.exists() && !f.isDirectory()) { 
		    xml();
		}else{
			new MujDialog(Menu,"Chyba", true, "Nenalezen soubor: "+ SOUBOR).setVisible(true);
		}
		loadConfig();
		if(POCET_SKUPIN < 1){
			new MujDialog(Menu,"Chyba",true,"Chybný soubor "+ SOUBOR +":"," -nedostateèný poèet otázek").setVisible(true);
		}
		
	}
	
	static void Quest(){
		Q = new Okno();
		Menu.setVisible(false);
		Q.setVisible(true);
	}
	static void Menu(){
		Q.setVisible(false);
		Menu.setVisible(true);
		Q=null;
		System.gc();
		Q = new Okno();
	}
	static String GetQ(int i){
		Node ot = null;
		Node sk = null;
		Node max = null;
		s = "";
		o1 = "";
		o2 = "";
		int maxOt;
		
		sk = getNode(Qroot,"skupina" + i);
		max = getNode(sk,"pocetOtazek");
		
		maxOt= Integer.parseInt(max.getTextContent());
		
		Random r = new Random();
		int a = r.nextInt(maxOt) +1;
		
		ot = getNode(sk,"otazka"+ a);
		Node zneni = getNode(ot,"zneni");
		Node odp1 = getNode(ot,"odpoved");
		Node odp2 = getNode(ot,"odpoved2");
		Node cest = getNode(ot,"cesta");
		
		s = zneni.getTextContent();
		o1 = odp1.getTextContent().toUpperCase();
		o2 = odp2.getTextContent().toUpperCase();
		cesta = cest.getTextContent();
		
		if(ot == null || s == "" || o1 == "" ){
			new MujDialog(Q, "Chyba", true,"Chybný soubor "+SOUBOR+":"," -chybìjící èásti otázky èíslo: " + i).setVisible(true);;
		}
		return s;
	}
	static void Reset(){
		Q.setVisible(false);
		Q = null;
		Q = new Okno();
		Q.setVisible(true);
	}
	private static Node getNode(Node rodic, String jmeno){
		NodeList n1 = rodic.getChildNodes();
		for(int i = 0; i <n1.getLength(); i++){
			Node e = n1.item(i);
			if (e.getNodeName().equals(jmeno) == true){
				return e;
			}
		}
		return null;
	}
	static boolean Check(String A){
		if(f.exists() && !f.isDirectory()) { 
		    //OK
		}else{
			new MujDialog(Menu,"Chyba", true, "Nenalezen soubor: "+ SOUBOR).setVisible(true);
			return false;
		}
		if(A.equals("")){
			return false;
		}
		if(A.equals(o1) == true || A.equals(o2)== true){
			return true;
		}
		else {
			return false;
		}
	}
	static void xml(){
		try{
			
			dbf = DocumentBuilderFactory.newInstance();
			dbf.setValidating(false);
			builder = dbf.newDocumentBuilder();
			builder.setErrorHandler(null);
			
			doc = builder.parse(SOUBOR);
			
			System.out.println(SOUBOR + " precten bez chyb");
			root = doc.getDocumentElement();
			Qroot = getNode(root,"otazky");
			Croot = getNode(root,"config");
			
		}catch (Exception e){
			e.printStackTrace();
			
		}
		
	}
	static void loadConfig(){
		Node pocetSK = getNode(Croot,"pocetSkupin");
		Node ver = getNode(Croot,"verze");
		Node rok = getNode(Croot,"rok");
		
		POCET_SKUPIN = Integer.parseInt(pocetSK.getTextContent());
		MAX_BODU=POCET_SKUPIN *2;
		VERZE = Double.parseDouble(ver.getTextContent());
		ROK = Integer.parseInt(rok.getTextContent());
	}
}
