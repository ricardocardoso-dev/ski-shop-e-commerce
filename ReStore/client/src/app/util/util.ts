export function getCookie(key : string) {
    const b = RegExp("(^|;)\\s*" + key + "\\s*=\\s*([^;]+)").exec(document.cookie);
    return b ? b.pop() : "";
  }

  export function currencyFormat(amount: number){
    return '$' + (amount/100).toFixed(2);
  }