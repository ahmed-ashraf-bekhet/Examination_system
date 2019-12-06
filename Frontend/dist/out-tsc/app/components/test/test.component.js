import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let TestComponent = class TestComponent {
    constructor(cookie, myService) {
        this.cookie = cookie;
        this.myService = myService;
    }
    ngOnInit() {
    }
    send() {
        this.myService.test(this.image).subscribe((data) => { console.log(data); }, (err) => { console.log(err); });
    }
    processFile(imageInput) {
        const file = imageInput.files[0];
        const reader = new FileReader();
        reader.addEventListener('load', (event) => {
            this.image = file;
        });
        reader.readAsDataURL(file);
    }
};
TestComponent = tslib_1.__decorate([
    Component({
        selector: 'app-test',
        templateUrl: './test.component.html',
        styleUrls: ['./test.component.css']
    })
], TestComponent);
export { TestComponent };
//# sourceMappingURL=test.component.js.map