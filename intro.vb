if not gumpexists 622436516 and skill "Necromancy" >= 50
    say '[NecromancyHotbar'
    wait 500
endif

# Make sure we have a spell book attached
if findlayer self righthand as item
    // do nothing
elseif findtype "3834" backpack as item
    dclick item
else 
    overhead "No book bro!" 34
endif