module ArabicToRoman

    type ArabToRoman = { arab : int; roman : string; remainder : int}

    let mapArabToRoman = 
        function
        | x when x >= 10 -> { arab = 10; roman = "X"; remainder = x - 10}
        | x when x >= 5 -> { arab = 5; roman = "V"; remainder = x - 5}
        | x when x >= 1 -> { arab = 1; roman = "I"; remainder = x - 1}
        | x -> { arab = 0; roman = ""; remainder = x}



    let convertToRoman arabic =

        let rec recConversion arab = 
            let arabToRoman = mapArabToRoman arab
            let remainder = arab - arabToRoman.arab
            if remainder = 0
            then arabToRoman.roman
            else arabToRoman.roman + recConversion (arab - arabToRoman.arab)

        recConversion arabic