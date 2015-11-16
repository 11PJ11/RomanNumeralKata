module ArabicToRoman


//to define a roman number we need some symbols
//these are:
//one five for each power of 10 so 0, 1, 2, 3
//These are used to convert from an arabic to a roman
//for example: 6 = five + one and based on the power of 10 we 
//             have different simbols so for 6 -> 10^0*(five :: one)
//                                             -> 10^0*five :: 10^0*one
//                                             -> V :: I -> VI
//  for 78 -> 10^1*(7) :: 10^0*(8)
//         -> 10^1*(five :: one :: one) :: 10^0*(five :: one :: one :: one)
//         -> (L :: X :: X) :: (V :: I :: I :: I)
//         -> LXXVIII

    type Power = Power of int
    type Digit = Digit of int 
    
    type ExpandedForm = { power : Power; digit : Digit }
    
    let expand (number:int) =
        let BIGGEST_POWER_OF_TEN = 3

        let rec go num pow (expansion:ExpandedForm list) =
           
            let powerOfTen = (int)((float)10 ** (float)pow)
            let digit = (int)(num / powerOfTen)
            let remainder = num - (digit * powerOfTen)
            let current = { power = Power(pow); digit = Digit(digit) }
            if pow = 0
            then expansion @ [current]
            else if digit > 0 && digit < 10
                   then [current] @ (go (remainder) (pow - 1) (expansion))
                   else (go (remainder) (pow - 1) (expansion))
    
        go number BIGGEST_POWER_OF_TEN []


    let getSymbolsBy expanded =
        match expanded.power with
        | Power(3) -> ("M" ,"", "")
        | Power(2) -> ("C" ,"D", "M")
        | Power(1) -> ("X" ,"L", "C")
        | Power(0) -> ("I", "V", "X")
        | _ -> ("", "", "")

    let fromDigitToRoman symbolsGetter expanded =
        let (one, five, ten) = symbolsGetter expanded
        match expanded.digit with
        | Digit(1)  -> one
        | Digit(2)  -> one + one
        | Digit(3)  -> one + one + one
        | Digit(4)  -> one + five
        | Digit(5)  -> five
        | Digit(6)  -> five + one
        | Digit(7)  -> five + one + one
        | Digit(8)  -> five + one + one + one
        | Digit(9)  -> one + ten
        | Digit(10) -> ten
        | _ -> ""

    let convertToRoman arabic =
        let expansion = expand arabic
        expansion
        |> List.map (fun exp -> fromDigitToRoman getSymbolsBy exp) 
        |> String.concat ""