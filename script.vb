###############
###  Choose your summons
######

@setvar! castSummonFireElementalCount 1
@setvar! castSummonCreatureCount 1
@setvar! castSummonEarthElementalCount 1
@setvar! castSummonEarthElementalAsMummy 1

@setvar! requireWitherBeforeSummons 1

@setvar! cdVengefulSpirit 30500
@setvar! cdMushroom 61000
@setvar! cdMeditation 10000
@setvar! cdMeditationMini 3000
@setvar! cdPreventSpamNecroAbilities 750
@setvar! cdWither 30500

##################################################################
# 
#   Hopefully you do not have to edit after this :)
#
##################################################################

# Setting current necro symbols - checks again it the attack loop
@setvar! necroSymbols 12
if gumpexists 622436516 and skill "Necromancy" >= 50
    if ingump "12/" 622436516
        @setvar! necroSymbols 12
    elseif ingump "13/" 622436516
        @setvar! necroSymbols 13
    elseif ingump "14/" 622436516
        @setvar! necroSymbols 14
    elseif ingump "15/" 622436516
        @setvar! necroSymbols 15
    elseif ingump "16/" 622436516
        @setvar! necroSymbols 16
    elseif ingump "17/" 622436516
        @setvar! necroSymbols 17
    elseif ingump "18/" 622436516
        @setvar! necroSymbols 18
    elseif ingump "19/" 622436516
        @setvar! necroSymbols 19
    elseif ingump "20/" 622436516
        @setvar! necroSymbols 20
    elseif ingump "21/" 622436516
        @setvar! necroSymbols 21
    elseif ingump "11/" 622436516
        @setvar! necroSymbols 11
    elseif ingump "10/" 622436516
        @setvar! necroSymbols 10
    elseif ingump "9/" 622436516
        @setvar! necroSymbols 9
    elseif ingump "8/" 622436516
        @setvar! necroSymbols 8
    elseif ingump "7/" 622436516
        @setvar! necroSymbols 7
    elseif ingump "6/" 622436516
        @setvar! necroSymbols 6
    elseif ingump "5/" 622436516
        @setvar! necroSymbols 5
    elseif ingump "4/" 622436516
        @setvar! necroSymbols 4
    elseif ingump "3/" 622436516
        @setvar! necroSymbols 3
    elseif ingump "2/" 622436516
        @setvar! necroSymbols 2
    elseif ingump "1/" 622436516
        @setvar! necroSymbols 1
    elseif ingump "0/" 622436516
        @setvar! necroSymbols 0
    endif
endif

if not timerexists magicMushroomTimer
    createtimer magicMushroomTimer
    settimer magicMushroomTimer cdMushroom
endif

if not timerexists meditiationTimer
    createtimer meditiationTimer
    settimer meditiationTimer cdMeditation
endif

if not timerexists vengefulSpiritTimer
    createtimer vengefulSpiritTimer
    settimer vengefulSpiritTimer cdVengefulSpirit
endif

if not timerexists witherTimer
    createtimer witherTimer
    settimer witherTimer cdWither
endif

if not timerexists preventSpamNecroAbilitiesTimer
    createtimer preventSpamNecroAbilitiesTimer
    settimer preventSpamNecroAbilitiesTimer cdPreventSpamNecroAbilities
endif

if not varexist myEarthPet
    @setvar! myEarthPet 0
endif

// make sure we have enough symbols to summon (6 for wither + vengful spirit)
if skill "Necromancy" >= 90 and requireWitherBeforeSummons = 1
    
	while followers < 4 and 6 > necroSymbols
        
		// we already have vengeful spirit active, skip the check
		if timer vengefulSpiritTimer < cdVengefulSpirit
           break
        endif
     
        if gumpexists 622436516 and skill "Necromancy" >= 50
            if ingump "12/" 622436516
                @setvar! necroSymbols 12
            elseif ingump "13/" 622436516
                @setvar! necroSymbols 13
            elseif ingump "14/" 622436516
                @setvar! necroSymbols 14
            elseif ingump "15/" 622436516
                @setvar! necroSymbols 15
            elseif ingump "16/" 622436516
                @setvar! necroSymbols 16
            elseif ingump "17/" 622436516
                @setvar! necroSymbols 17
            elseif ingump "18/" 622436516
                @setvar! necroSymbols 18
            elseif ingump "19/" 622436516
                @setvar! necroSymbols 19
            elseif ingump "20/" 622436516
                @setvar! necroSymbols 20
            elseif ingump "21/" 622436516
                @setvar! necroSymbols 21
            elseif ingump "11/" 622436516
                @setvar! necroSymbols 11
            elseif ingump "10/" 622436516
                @setvar! necroSymbols 10
            elseif ingump "9/" 622436516
                @setvar! necroSymbols 9
            elseif ingump "8/" 622436516
                @setvar! necroSymbols 8
            elseif ingump "7/" 622436516
                @setvar! necroSymbols 7
            elseif ingump "6/" 622436516
                @setvar! necroSymbols 6
            elseif ingump "5/" 622436516
                @setvar! necroSymbols 5
            elseif ingump "4/" 622436516
                @setvar! necroSymbols 4
            elseif ingump "3/" 622436516
                @setvar! necroSymbols 3
            elseif ingump "2/" 622436516
                @setvar! necroSymbols 2
            elseif ingump "1/" 622436516
                @setvar! necroSymbols 1
            elseif ingump "0/" 622436516
                @setvar! necroSymbols 0
            endif
        endif
    endwhile
endif


if not varexist lichOne
    @setvar! lichOne 0
endif

if not varexist lichTwo
    @setvar! lichTwo 0
endif

if not varexist earthOne
    @setvar! earthOne 0
endif

if not varexist earthTwo
    @setvar! earthTwo 0
endif

if lichOne = creatureOne or lichTwo = creatureOne or earthOne = creatureOne or earthTwo = creatureOne
    overhead "Duplicated"
    unsetvar creatureOne
endif


if castSummonEarthElementalCount > 0
    if diffhits < 30
        if followers = 0
            @setvar! followCount 0
        elseif followers = 1
            @setvar! followCount 1
        elseif followers = 2
            @setvar! followCount 2
        elseif followers = 3
            @setvar! followCount 3
        elseif followers = 4
            @setvar! followCount 4
        elseif followers = 5
            @setvar! followCount 5
        endif
        if dead earthOne or not find earthOne ground -1 -1 12
            if followers < 4
                while mana < 50
                    if diffhits >= 30
                        replay
                    endif
                    if not findbuff "Actively Meditating"
                        useskill "meditation"
                    endif
                    wait 200
                endwhile
                
                if castSummonEarthElementalAsMummy = 1
                    if timer vengefulSpiritTimer >= cdVengefulSpirit and skill "Necromancy" >= 50
                        yell "[VengefulSpirit"
                        settimer vengefulSpiritTimer 0
                        wait 500
                    endif
                elseif timer vengefulSpiritTimer <= cdVengefulSpirit and skill "Necromancy" >= 50
                    overhead  "Waiting for spirit to go away" 
                    replay
                endif
                while followers = followCount
                    cast "Earth elemental"
                    wait 500
                    if timer witherTimer >= cdWither and skill "Necromancy" >= 95
                        yell "[Wither"
                        settimer witherTimer 0
                    endif
                    if diffhits >= 30
                        hotkey '> Interrupt'
                        break
                    endif
                endwhile
            endif
        endif
    endif
    
    if diffhits < 30 and castSummonEarthElementalCount > 1
        if followers = 0
            @setvar! followCount 0
        elseif followers = 1
            @setvar! followCount 1
        elseif followers = 2
            @setvar! followCount 2
        elseif followers = 3
            @setvar! followCount 3
        elseif followers = 4
            @setvar! followCount 4
        elseif followers = 5
            @setvar! followCount 5
        endif
        if dead earthTwo or not find earthTwo ground -1 -1 12
            if followers < 4
                while mana < 50
                    if diffhits >= 30
                        replay
                    endif
                    if not findbuff "Actively Meditating"
                        useskill "meditation"
                    endif
                    wait 200
                endwhile
                if timer vengefulSpiritTimer >= cdVengefulSpirit and skill "Necromancy" >= 50
                    yell "[VengefulSpirit"
                    settimer vengefulSpiritTimer 0
                    wait 500
                endif
                while followers = followCount
                    cast "Earth elemental"
                    wait 500
                    if timer witherTimer >= cdWither and skill "Necromancy" >= 95
                        yell "[Wither"
                        settimer witherTimer 0
                    endif
                    if diffhits >= 30
                        hotkey '> Interrupt'
                        break
                    endif
                endwhile
            endif
        endif
    endif
endif


if castSummonFireElementalCount > 0
    if diffhits < 30
    
        if lichOne = 0 
            // do nothing
        elseif lichOne = lichTwo
            overhead "Duplicated"
            unsetvar lichOne
        endif
        
        if followers = 0
            @setvar! followCount 0
        elseif followers = 1
            @setvar! followCount 1
        elseif followers = 2
            @setvar! followCount 2
        elseif followers = 3
            @setvar! followCount 3
        elseif followers = 4
            @setvar! followCount 4
        elseif followers = 5
            @setvar! followCount 5
        endif
        if dead lichOne or not find lichOne ground -1 -1 12 or dead lichTwo
            if followers < 4
                while mana < 50
                    if diffhits >= 30
                        replay
                    endif
                    if not findbuff "Actively Meditating"
                        useskill "meditation"
                    endif
                    wait 200
                endwhile
                if timer vengefulSpiritTimer >= cdVengefulSpirit and skill "Necromancy" >= 50
                    yell "[VengefulSpirit"
                    settimer vengefulSpiritTimer 0
                    wait 500
                endif
                @ignore lichTwo
                while followers = followCount
                    if targetexists 
                        hotkey 'Cancel Current Target'
                endif
                    cast "fire elemental"
                    wait 500
                    if timer witherTimer >= cdWither and skill "Necromancy" >= 95
                        yell "[Wither"
                        settimer witherTimer 0
                    endif
                    if diffhits >= 30
                        hotkey '> Interrupt'
                        break
                    endif
                endwhile
            endif
        endif
    endif
    
    if diffhits < 30 and castSummonFireElementalCount > 1
        if followers = 0
            @setvar! followCount 0
        elseif followers = 1
            @setvar! followCount 1
        elseif followers = 2
            @setvar! followCount 2
        elseif followers = 3
            @setvar! followCount 3
        elseif followers = 4
            @setvar! followCount 4
        elseif followers = 5
            @setvar! followCount 5
        endif
        if dead lichTwo or not find lichTwo ground -1 -1 12 or dead lichOne
            if followers < 4
                while mana < 50
                    if diffhits >= 30
                        replay
                    endif
                    if not findbuff "Actively Meditating"
                        useskill "meditation"
                    endif
                    wait 200
                endwhile
                if timer vengefulSpiritTimer >= cdVengefulSpirit and skill "Necromancy" >= 50
                    yell "[VengefulSpirit"
                    settimer vengefulSpiritTimer 0
                    wait 500
                endif
                @ignore lichOne
                while followers = followCount
                     if targetexists 
                        hotkey 'Cancel Current Target'
                     endif
                    cast "fire elemental"
                    wait 500
                    if timer witherTimer >= cdWither and skill "Necromancy" >= 95
                        yell "[Wither"
                        settimer witherTimer 0
                    endif
                    if diffhits >= 30
                        hotkey '> Interrupt'
                        break
                    endif
                endwhile
            endif
        endif
    endif
endif

if castSummonCreatureCount = 0
    // do nothing
elseif castSummonCreatureCount = 1 and not dead creatureOne
    // do nothing
elseif castSummonCreatureCount = 1
    if followers = 4 and diffhits < 30
        if followers = 0
            @setvar! followCount 0
        elseif followers = 1
            @setvar! followCount 1
        elseif followers = 2
            @setvar! followCount 2
        elseif followers = 3
            @setvar! followCount 3
        elseif followers = 4
            @setvar! followCount 4
        elseif followers = 5
            @setvar! followCount 5
        endif
        while mana < 14
            if diffhits >= 30
                replay
            endif
            if not findbuff "Actively Meditating"
                useskill "meditation"
            endif
            wait 200
        endwhile
        if timer vengefulSpiritTimer >= cdVengefulSpirit
            yell "[VengefulSpirit"
            settimer vengefulSpiritTimer 0
            wait 200
        endif
        while followers = followCount
                 if targetexists 
                        hotkey 'Cancel Current Target'
                endif
            cast 'Summ. Creature'
            wait 500
            if diffhits >= 30
                hotkey '> Interrupt'
                replay
            endif
        endwhile        
        say "all guard me"
    endif
else
    for 6
        if index = 0
            // do nothing
        else
            if diffhits < 30
                @setvar! needToSummon 0
                if index = 1
                    if dead creatureOne or not find creatureOne ground -1 -1 12
                        @setvar! needToSummon 1
                    endif
                elseif index = 2
                    if dead creatureTwo or not find creatureTwo ground -1 -1 12
                        @setvar! needToSummon 1
                    endif
                elseif index = 3
                    if dead creatureThree or not find creatureThree ground -1 -1 12
                        @setvar! needToSummon 1
                    endif
                elseif index = 4
                    if dead creatureFour or not find creatureFour ground -1 -1 12
                        @setvar! needToSummon 1
                    endif
                elseif index = 5
                    if dead creatureFive or not find creatureFive ground -1 -1 12
                        @setvar! needToSummon 1
                    endif
                endif
            
                if needToSummon = 1
                    if followers = 0
                        @setvar! followCount 0
                    elseif followers = 1
                        @setvar! followCount 1
                    elseif followers = 2
                        @setvar! followCount 2
                    elseif followers = 3
                        @setvar! followCount 3
                    elseif followers = 4
                        @setvar! followCount 4
                    elseif followers = 5
                        @setvar! followCount 5
                    endif
                   
                    while mana < 50
                        if diffhits >= 30
                            replay
                        endif
                        if not findbuff "Actively Meditating"
                            useskill "meditation"
                        endif
                        wait 200
                    endwhile
                    if timer vengefulSpiritTimer >= cdVengefulSpirit and skill "Necromancy" >= 50
                        yell "[VengefulSpirit"
                        settimer vengefulSpiritTimer 0
                        wait 500
                    endif
                    while followers = followCount
                        cast "Summ. Creature"
                        wait 500
                        if timer witherTimer >= cdWither and skill "Necromancy" >= 95
                            yell "[Wither"
                            settimer witherTimer 0
                        endif
                        if diffhits >= 30
                            hotkey '> Interrupt'
                            break
                        endif
                    endwhile
                    hotkey 'Next Friendly Monster Target'
                    @setvar! checkLastTarget lasttarget
                    if checkLastTarget = earthOne
                        hotkey 'Next Friendly Monster Target'
                        @setvar! checkLastTarget lasttarget 
                    endif
                    
                    if checkLastTarget = earthTwo
                       hotkey 'Next Friendly Monster Target'
                       @setvar! checkLastTarget lasttarget 
                    endif
                    
                    if checkLastTarget = lichOne
                       hotkey 'Next Friendly Monster Target'
                       @setvar! checkLastTarget lasttarget 
                    endif
                    
                    if checkLastTarget = lichTwo
                       hotkey 'Next Friendly Monster Target'
                       @setvar! checkLastTarget lasttarget 
                    endif
                    @setvar! creatureOne checkLastTarget
                    
                    if find checkLastTarget ground -1 -1 6 as myPet
                        if index = 1
                            if dead creatureOne or not find creatureOne ground -1 -1 12
                                @setvar! creatureOne myPet
                            endif
                        elseif index = 2
                            if dead creatureTwo or not find creatureTwo ground -1 -1 12
                                @setvar! creatureTwo myPet
                            endif
                        elseif index = 3
                            if dead creatureThree or not find creatureThree ground -1 -1 12
                                @setvar! creatureThree myPet
                            endif
                        elseif index = 4
                            if dead creatureFour or not find creatureFour ground -1 -1 12
                                @setvar! creatureFour myPet
                            endif
                        elseif index = 5
                            if dead creatureFive or not find creatureFive ground -1 -1 12
                                @setvar! creatureFive myPet
                            endif
                        endif
                    endif
                endif
            endif
        endif
        if index = castSummonCreatureCount
            break
        endif
    endfor
endif


