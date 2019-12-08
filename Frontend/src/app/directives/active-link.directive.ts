import { Directive, HostListener, ElementRef } from '@angular/core';

@Directive({
  selector: '[appActiveLink]'
})
export class ActiveLinkDirective {

  constructor(private myElement: ElementRef) { }

  @HostListener('focus') onFocus() {
    this.myElement.nativeElement.parentElement.classList.add("active");
  }

  @HostListener('focusout') onFocusOut() {
    this.myElement.nativeElement.parentElement.classList.remove("active");
  }
}
