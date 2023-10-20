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
public class Menu extends Zaklad {
	Button Start;
	Button Exit;
	Button Info;
	Platno pl;
	GridBagLayout gbl;
	GridBagConstraints gbc;
	
	Menu(){
		gbl = new GridBagLayout();
		gbc = new GridBagConstraints();
		gbc.gridx =0;
		this.setFont(new Font("Sherif", Font.PLAIN, 40));
		this.setBackground(Color.black);
		this.setForeground(Color.white);
		pl = new Platno();
		pl.setBounds(0, 0, 300, 293);
		this.add(pl);
		
		this.setLayout(gbl);
		
		Start = new Button("Start");
		gbc.gridy = 1;
		gbl.setConstraints(Start, gbc);
		this.add(Start);
		Start.setBackground(Color.black);
		
		Info = new Button("O Programu");
		gbc.gridy = 2;
		gbl.setConstraints(Info, gbc);
		this.add(Info);
		Info.setBackground(Color.black);
		
		Exit = new Button("Exit");
		gbc.gridy = 3;
		gbl.setConstraints(Exit, gbc);
		this.add(Exit);
		Exit.setBackground(Color.black);
		
		pl.drawImg();
		
		Start.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				Hlavni.Quest();
			}
		});
		Info.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				Info();
			}
		});
		Exit.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e){
				System.exit(0);
			}
		});
		Exit.addKeyListener(new KeyAdapter() 
        {
            public void keyPressed(KeyEvent evt)
            {
                if(evt.getKeyCode() == KeyEvent.VK_ENTER)
                {
                	System.exit(0);
                }
            }
        });
		Info.addKeyListener(new KeyAdapter() 
        {
            public void keyPressed(KeyEvent evt)
            {
                if(evt.getKeyCode() == KeyEvent.VK_ENTER)
                {
                	Info();
                }
            }
        });
		Start.addKeyListener(new KeyAdapter() 
        {
            public void keyPressed(KeyEvent evt)
            {
                if(evt.getKeyCode() == KeyEvent.VK_ENTER)
                {
                	Hlavni.Quest();
                }
            }
        });
	}
	void Info(){
		new MujDialog(main.Hlavni.Q,"O Programu", true, " verze: "+ main.Hlavni.VERZE+", Licence: GNU/GPL", "Copyright: 2016 Štìpán Venclík").setVisible(true);
	}
	
}

