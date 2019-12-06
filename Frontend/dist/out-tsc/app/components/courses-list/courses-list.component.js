import * as tslib_1 from "tslib";
import { Component, Input } from '@angular/core';
let CoursesListComponent = class CoursesListComponent {
    constructor(courseService) {
        this.courseService = courseService;
    }
    ngOnInit() {
        if (this.deptID)
            this.getDepartmentCourses(this.deptID);
        else
            this.getAllCourses();
    }
    getAllCourses() {
        this.courseService.getAllCourses().subscribe((data) => {
            this.courses = data;
            if (this.courses_number > 0)
                this.courses = this.courses.slice(0, this.courses_number);
        }, (error) => {
            console.log(error);
        });
    }
    getDepartmentCourses(deptID) {
        this.courseService.getDepartmentCourses(deptID).subscribe((data) => {
            this.courses = data;
        }, (error) => {
            console.log(error);
        });
    }
};
tslib_1.__decorate([
    Input()
], CoursesListComponent.prototype, "courses_number", void 0);
tslib_1.__decorate([
    Input()
], CoursesListComponent.prototype, "deptID", void 0);
CoursesListComponent = tslib_1.__decorate([
    Component({
        selector: 'app-courses-list',
        templateUrl: './courses-list.component.html',
        styleUrls: ['./courses-list.component.css']
    })
], CoursesListComponent);
export { CoursesListComponent };
//# sourceMappingURL=courses-list.component.js.map