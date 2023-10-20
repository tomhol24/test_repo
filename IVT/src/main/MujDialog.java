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

@SuppressWarnings("serial")
public class MujDialog extends Dialog{
	public MujDialog(Frame owner,String s, boolean modal, String t, String t2) {
		super(owner, s, modal);
		this.setLayout(new FlowLayout());
		this.setSize(250,125);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.setFont(new Font("Sherif", Font.PLAIN, 14));
		this.setBackground(Color.black);
		this.setForeground(Color.white);

		Label lb = new Label(t);
		this.add(lb);
		
		Label lb2 = new Label(t2);
		this.add(lb2);
		
		Button bt = new Button("Zavøít");
		this.add(bt);
		bt.setBackground(Color.black);
		
		if(s.equals("Chyba")==true){
			bt.setLabel("Exit");
		}
	
		bt.addKeyListener(new KeyListener(){
			public void keyPressed(KeyEvent e){
				if(Chyba()==true){
					System.exit(1);
				}else{
					try {
						Close();
					} catch (Throwable e1) {
						e1.printStackTrace();
					}
				}
			}
			public void keyReleased(KeyEvent arg0) {}
			public void keyTyped(KeyEvent arg0) {}
		});
		
		bt.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				if((Chyba()==true)){
					System.exit(1);
				}else{
					try {
						Close();
					} catch (Throwable e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		addWindowListener(new WindowAdapter(){
			public void windowClosing(WindowEvent e){
				if((Chyba()==true)){
					System.exit(1);
				}else{
					try {
						Close();
					} catch (Throwable e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		
	}
	public MujDialog(Frame owner,String s, boolean modal, String t) {
		super(owner, s, modal);
		this.setLayout(new FlowLayout());
		this.setSize(250,100);
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		this.setBackground(Color.black);
		this.setForeground(Color.white);
		
		
		Label lb = new Label(t);
		this.add(lb);
		this.setFont(new Font("Sherif", Font.PLAIN, 14));
		
		Button bt = new Button("Zavøít");
		bt.setBackground(Color.black);
		this.add(bt);
		
		if(s.equals("Chyba")==true){
			bt.setLabel("Exit");
		}
		
		bt.addKeyListener(new KeyListener(){
			public void keyPressed(KeyEvent e){
				if((Chyba()==true)){
					System.exit(1);
				}else{
					try {
						Close();
					} catch (Throwable e1) {
						e1.printStackTrace();
					}
				}
			}
			public void keyReleased(KeyEvent arg0) {}
			public void keyTyped(KeyEvent arg0) {}
		});
		
		bt.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				if((Chyba()==true)){
					System.exit(1);
				}else{
					try {
						Close();
					} catch (Throwable e1) {				
						e1.printStackTrace();
					}
				}
			}
		});
		addWindowListener(new WindowAdapter(){
			public void windowClosing(WindowEvent e){
				if((Chyba()==true)){
					System.exit(1);
				}else{
					try {
						Close();
					} catch (Throwable e1) {
						e1.printStackTrace();
					}
				}
			}
		});
		
	}
	void Close() throws Throwable{
		this.setVisible(false);
		this.finalize();
	}
	boolean Chyba(){
		if(this.getTitle()=="Chyba"){
			return true;
		}else{
			return false;
		}
	}
	
}