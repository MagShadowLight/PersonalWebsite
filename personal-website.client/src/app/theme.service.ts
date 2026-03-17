import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  enableDarkMode(): void {
    this.ToggleDarkMode(true);
  }

  disableDarkMode(): void {
    this.ToggleDarkMode(false);
    
  }

  ToggleDarkMode(isDarkMode: boolean) : void {
    // if (isDarkMode) {
    //   const elementSignal = signal(element);
    //   element?.classList.remove("light-mode")
    //   element?.classList.add("dark-mode");
    //   elementSignal.set(element);
    // } else {
    //   const elementSignal = signal(element);
    //   element?.classList.remove("dark-mode");
    //   element?.classList.add('lightmode');
    //   elementSignal.set(element);
    // }
  
    document.getElementsByTagName("html")[0].setAttribute("data-bs-theme", (isDarkMode ? "dark" : "light"));
  }

  getElement(elementId: string) : HTMLElement | null {
    var element = document.getElementById(elementId);
    return element
  }

}
