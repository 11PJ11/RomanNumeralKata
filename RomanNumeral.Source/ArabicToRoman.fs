module ArabicToRoman

    type ArabToRoman = { arab : int; roman : string; }

    let mapArabToRoman = 
        function
        | x when x >= 10 -> { arab = 10; roman = "X"}
        | x when x >= 5 -> { arab = 5; roman = "V"}
        | x when x >= 1 -> { arab = 1; roman = "I"}
        | _ -> { arab = 0; roman = ""}



    let convertToRoman arabic =

        let rec recConversion arab = 
            let arabToRoman = mapArabToRoman arab
            let remainder = arab - arabToRoman.arab
            if remainder = 0
            then arabToRoman.roman
            else arabToRoman.roman + recConversion (arab - arabToRoman.arab)

        recConversion arabic