export function getCookie(key : string) {
    const b = RegExp("(^|;)\\s*" + key + "\\s*=\\s*([^;]+)").exec(document.cookie);
    return b ? b.pop() : "";
  }