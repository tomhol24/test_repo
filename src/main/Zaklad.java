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
public abstract class Zaklad extends Frame {
	
	Zaklad(){
		this.setLayout(new FlowLayout());
		super.setTitle("Test: MS-DOS");
		this.setSize(1000,500);
		this.setFont(new Font("Serif", Font.PLAIN,20));
		this.setLocationRelativeTo(null);
		this.setResizable(false);
		
		addWindowListener(new WindowAdapter(){
			public void windowClosing(WindowEvent e){
				System.exit(0);
			}
		});
	}
}