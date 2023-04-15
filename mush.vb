

if counttype "mushroom" backpack < butOnlyIHaveLessThenThisCount
    while counttype "mushroom" backpack < makeThisManyMushroomsCount
        cast "Create Food"
        wait 200
        if diffhits >= 20 or counttype "mushroom" backpack = 0
            break
        endif
    endwhile
endif