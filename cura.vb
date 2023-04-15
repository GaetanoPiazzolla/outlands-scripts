if diffhits >= 30
	if targetexists 
		hotkey 'Cancel Current Target'
	endif
	while not targetexists 'beneficial'
		if diffhits >= 60
			cast 'Heal'
		else
			cast 'Greater Heal'                
		endif
		wait 50
		if hp = maxhp
			hotkey '> Interrupt'
			break
		endif
	endwhile
	if targetexists 'beneficial'
		hotkey 'Target Self'
	endif
endif

if poisoned
	if findtype "Orange Potion" backpack
		while poisoned and findtype "Orange Potion" backpack kpot 
		dclick pot
		wait 100
		endwhile
	else
		overhead "Casting Cure"
		while poisoned and diffhits <= 30 and not targetexists 
		    cast 'Cure'
			wait 50
			endwhile
		endif
		if targetexists
			target self
			wait 500
		endif
	endif
endif