module ArabicToRoman

//WITH PIPES

    let closestArab arab = 
        match arab with
        | x when x >= 10 -> 10
        | x when x >=  5 -> 5
        | x when x  =  4 -> 4
        | x when x >=  1 -> 1
        | _ -> 0

    let fromArabToRoman arab = 
        match arab with
        | 10 -> "X"
        | 5 -> "V"
        | 4 -> "IV"
        | 1 -> "I"
        | _ -> ""

    let toClosestWithRoman arab = 
        let closest = arab |> closestArab 
        let roman = closest |> fromArabToRoman
        (closest, roman)

    let convertToRoman2 arabic =

        let rec recConversion2 arab = 
            let (closest, roman) =  arab |> toClosestWithRoman 
            let remainder = arab - closest
            if remainder = 0
            then roman
            else roman + (recConversion2 remainder)

        recConversion2 arabic


//WITH DATA TYPES

    type ArabToRoman = { arab : int; roman : string; remainder : int}

    let mapArabToRoman = 
        function
        | x when x >= 10 -> { arab = 10; roman = "X"; remainder = x - 10}
        | x when x >= 5 -> { arab = 5; roman = "V"; remainder = x - 5}
        | x when x = 4 -> { arab = 4; roman = "IV"; remainder = x - 4}
        | x when x >= 1 -> { arab = 1; roman = "I"; remainder = x - 1}
        | x -> { arab = 0; roman = ""; remainder = x}



    let convertToRoman arabic =

        let rec recConversion arab = 
            let arabToRoman = mapArabToRoman arab
            if arabToRoman.remainder = 0
            then arabToRoman.roman
            else arabToRoman.roman + recConversion (arab - arabToRoman.arab)

        recConversion arabic