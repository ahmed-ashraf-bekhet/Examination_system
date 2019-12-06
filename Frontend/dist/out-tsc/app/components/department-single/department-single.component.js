import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let DepartmentSingleComponent = class DepartmentSingleComponent {
    constructor(myService, myRouter) {
        this.myService = myService;
        this.myRouter = myRouter;
        this.departmentID = this.myRouter.snapshot.params['id'];
    }
    ngOnInit() {
        this.getDepartment(this.departmentID);
    }
    getDepartment(ID) {
        this.myService.getDepartment(ID).subscribe((data) => {
            this.department = data[0];
        }, (error) => {
            console.log(error);
        });
    }
    getStudentsNumber(ID) {
        return 50;
    }
    getTeachersNumber(DepartmentID) {
        return 8;
    }
    getCoursesNumber(DepartmentID) {
        return 4;
    }
};
DepartmentSingleComponent = tslib_1.__decorate([
    Component({
        selector: 'app-department-single',
        templateUrl: './department-single.component.html',
        styleUrls: ['./department-single.component.css']
    })
], DepartmentSingleComponent);
export { DepartmentSingleComponent };
//# sourceMappingURL=department-single.component.js.map