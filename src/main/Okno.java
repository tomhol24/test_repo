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

import java.awt.*;
import java.awt.event.*;
import java.util.*;

@SuppressWarnings("serial")
public class Okno extends Zaklad{
	
	Button NextBT;
	Label preA;
	TextArea Ques;
	TextField AnswerB;
	Label State;
	Button CheckBT;
	Label Body;
	Label OtN;
	Label Label1;
	GridBagLayout gbl;
	GridBagConstraints gbc;
	MenuBar lista;
	MenuItem m11;
	MenuItem m12;
	MenuItem m21;
	MenuItem m22;
	int pokus;
	
	int[] poradi;
	int rnd;
	int body = 0;
	int ot = 1;
	String s;
	
	Okno() {
		gbl = new GridBagLayout();
		gbc = new GridBagConstraints();
		this.setLayout(gbl);
		this.setBackground(Color.black);
		this.setForeground(Color.white);
		
		poradi = new int[Hlavni.POCET_SKUPIN +1];
		
		for(int i = 1;i<=Hlavni.POCET_SKUPIN;i++){
			Random r = new Random();
			int a = r.nextInt(main.Hlavni.POCET_SKUPIN) +1;
			
			for(int z=1; z <= Hlavni.POCET_SKUPIN; z++){
				if(a == poradi[z]){
					z = 0;
					a = r.nextInt(main.Hlavni.POCET_SKUPIN) +1;
				}
			}
			
			poradi[i]= a;
		}
		
		DrawQW();
		NQ();
		
		//AKCE
		
		CheckBT.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				Step();
			}
		});
		
		NextBT.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				if(NextBT.getLabel() == "Menu"){
					main.Hlavni.Menu();
				}
				if(pokus==1){
					Pokus2();
				}
				else {
					Cycle();
				}
			}
		});
		
		m11.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				main.Hlavni.Reset();
			}
		});
		m12.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				System.exit(0);
			}
		});
		m21.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				new MujDialog(main.Hlavni.Q, "Help", true,"OK/Další/Menu = klávesa ENTER", "Pozor na zdvojené mezery! ").setVisible(true);
			}
		});
		m22.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				new MujDialog(main.Hlavni.Q,"O Programu", true, " verze: "+ main.Hlavni.VERZE+", Licence: GNU/GPL", "Copyright: 2016 Štìpán Venclík").setVisible(true);
			}
		});
		//ENTER
		AnswerB.addKeyListener(new KeyListener(){
			public void keyPressed(KeyEvent e){
				Event(e);
			}
			public void keyReleased(KeyEvent arg0) {}
			public void keyTyped(KeyEvent arg0) {}
		});
		NextBT.addKeyListener(new KeyListener(){
			public void keyPressed(KeyEvent e){
				Event(e);
			}
			public void keyReleased(KeyEvent arg0) {}
			public void keyTyped(KeyEvent arg0) {}
		});
		CheckBT.addKeyListener(new KeyListener(){
			public void keyPressed(KeyEvent e){
				Event(e);
			}
			public void keyReleased(KeyEvent arg0) {}
			public void keyTyped(KeyEvent arg0) {}
				
		});
		
	}
	void Event(KeyEvent e){
		if(e.getKeyCode() == KeyEvent.VK_ENTER)
    	{
    		if(ot== 0){
    			main.Hlavni.Menu();
				return;
			}
    		if(CheckBT.isEnabled()==true){
        		Step();
    		}else{
        		if(pokus == 1){
					Pokus2();
				}
				else{
					Cycle();
				}
        	}
    	}
  }
	void Cycle(){
		if(ot >= Hlavni.POCET_SKUPIN){
			NextBT.setLabel("Menu");
			ot = 0;
			DrawSW();
			
		}
		else{
			AnswerB.setEditable(true);
			AnswerB.setText(null);
			AnswerB.setFocusable(true);
			CheckBT.setEnabled(true);
			State.setText("");
			NextBT.setEnabled(false);
			
			
			ot++;
			NQ();
		
			OtN.setText("Otázka èíslo: " + ot + "/" + Hlavni.POCET_SKUPIN);
			
		}
		
	}
	void Step(){
		AnswerB.setEditable(false);
		AnswerB.setFocusable(false);
		CheckBT.setEnabled(false);
		String a = AnswerB.getText().toUpperCase();
		
		
		boolean valid;
		
		valid = main.Hlavni.Check(a);
		
		if(valid == true){
			State.setForeground(Color.green);
			int i = 2- pokus;
			body=body +i;
			pokus = 0;
			if(i==1){
				State.setText("Správnì. +" +i+" bod.");
			}
			else{
				State.setText("Správnì. +" +i+" body.");
			}
		}else{
			pokus++;
			if(pokus==1){
				State.setForeground(Color.red);
				State.setText("Chyba! Zbývá jeden pokus.");
			}
			else{
				State.setForeground(Color.red);
				State.setText("Chyba! Nezbývá už žádný pokus.");
				pokus = 0;
			}
			
		}
		NextBT.setEnabled(true);
		NextBT.requestFocus();
		Body.setText("Poèet bodù : " + body +"/"+Hlavni.MAX_BODU);
	}
	void DrawQW(){
		Body = new Label("Poèet bodù : " + body +"/" + Hlavni.MAX_BODU + " ");
		gbc.gridx = 0;
		gbc.gridy = 0;
		gbc.gridwidth = 2;
		gbl.setConstraints(Body, gbc);
		this.add(Body);
		gbc.gridwidth = 1;
		
		OtN = new Label("Otázka èíslo: " + ot + "/" + Hlavni.POCET_SKUPIN + "");
		gbc.gridx = 5;
		gbl.setConstraints(OtN, gbc);
		this.add(OtN);
		
		Label1 = new Label("Otázka:");
		gbc.gridx = 2;
		gbc.gridy = 1;
		gbl.setConstraints(Label1, gbc);
		this.add(Label1);
		
		Ques = new TextArea(s,5,20,TextArea.SCROLLBARS_NONE);
		Ques.setEditable(false);
		Ques.setFocusable(false);
		Ques.setBackground(Color.black);
		Ques.setForeground(Color.white);
		Ques.setFont(new Font("Sherif", Font.PLAIN,20));
		gbc.gridx = 3;
		gbc.gridy = 2;
		gbc.gridwidth =2;
		gbc.fill = GridBagConstraints.BOTH;
		gbl.setConstraints(Ques, gbc);
		this.add(Ques);
		gbc.fill = GridBagConstraints.NONE;
		gbc.gridwidth = 1;
		
		preA= new Label("                  ");	
		preA.setFont(new Font("Sherif", Font.BOLD,20));
		preA.setAlignment(Label.RIGHT);
		gbc.gridx = 1;
		gbc.gridy = 3;
		gbc.gridwidth = 2;
		gbc.fill = GridBagConstraints.BOTH;
		gbl.setConstraints(preA, gbc);
		this.add(preA);
		
		AnswerB = new TextField(50);
		AnswerB.setBackground(Color.black);
		AnswerB.setForeground(Color.white);
		AnswerB.setFont(new Font("Sherif", Font.BOLD,20));
		gbc.gridx = 3;
		gbc.gridwidth = 2;
		gbl.setConstraints(AnswerB, gbc);
		this.add(AnswerB);
		gbc.gridwidth = 1;
		
		CheckBT = new Button("OK");
		gbc.gridx = 4;
		gbc.gridy = GridBagConstraints.RELATIVE;
		gbc.fill = GridBagConstraints.NONE;
		CheckBT.setBackground(Color.black);
		gbl.setConstraints(CheckBT, gbc);
		this.add(CheckBT);
		
		State = new Label("", Label.CENTER);
		gbc.gridx = 3;
		gbc.gridwidth = 2;
		gbc.fill = GridBagConstraints.BOTH;
		gbl.setConstraints(State, gbc);
		this.add(State);
		
		NextBT = new Button("Další");
		gbc.gridx = 3;
		gbc.fill = GridBagConstraints.NONE;
		gbl.setConstraints(NextBT, gbc);
		NextBT.setBackground(Color.black);
		this.add(NextBT);
		NextBT.setEnabled(false);
		
		lista = new MenuBar();
		this.setMenuBar(lista);
		java.awt.Menu m1 = new java.awt.Menu("Menu", true);
		java.awt.Menu m2 = new java.awt.Menu("Help",true);
		lista.add(m1);
		lista.add(m2);
		m11 = new MenuItem("Reset");
		m12 = new MenuItem("Exit");
		m1.add(m11);
		m1.add(m12);
		m21 = new MenuItem("Help");
		m22 = new MenuItem("O programu");
		m2.add(m21);
		m2.add(m22);

	}

	void DrawSW(){
		Ques.setText("Dosažený poèet bodù : "+body +"/" + Hlavni.MAX_BODU);
		Ques.setFont(new Font("Serif", Font.BOLD, 38));
		preA.setVisible(false);
		AnswerB.setVisible(false);
		State.setVisible(false);
		CheckBT.setVisible(false);
		Body.setVisible(false);
		OtN.setVisible(false);
		Label1.setVisible(false);

	}
	
	void NQ(){
		s = main.Hlavni.GetQ(poradi[ot]);
		Ques.setText(s);
		preA.setText(Hlavni.cesta);
	}
	void Pokus2(){
		AnswerB.setEditable(true);
		AnswerB.setText(null);
		AnswerB.setFocusable(true);
		CheckBT.setEnabled(true);
		State.setText("");
		NextBT.setEnabled(false);
	}
}
