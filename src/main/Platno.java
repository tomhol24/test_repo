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
import java.awt.Toolkit;

@SuppressWarnings("serial")
public class Platno extends Canvas{
	Image img = null;
	
	void drawImg(){
		Toolkit t = this.getToolkit();
		this.img = t.getImage("data/cmd.png");
		repaint();
		
	}
	public void paint(Graphics g){
		Dimension d = getSize();
		if(img !=null){
			g.drawImage(img, 0, 0, d.width -1, d.height -1,this);
		}
	}
}
