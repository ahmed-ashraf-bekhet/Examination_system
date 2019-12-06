import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let DepartmentsComponent = class DepartmentsComponent {
    constructor(myService) {
        this.myService = myService;
    }
    ngOnInit() {
        this.getDepartments();
    }
    getDepartments() {
        this.myService.getAllDepartments().subscribe((data) => {
            console.log(data);
            this.departments = data;
        }, (error) => {
            console.log(error);
        });
    }
};
DepartmentsComponent = tslib_1.__decorate([
    Component({
        selector: 'app-departments',
        templateUrl: './departments.component.html',
        styleUrls: ['./departments.component.css']
    })
], DepartmentsComponent);
export { DepartmentsComponent };
//# sourceMappingURL=departments.component.js.map