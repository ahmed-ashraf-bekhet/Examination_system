import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { GuestHeaderComponent } from './components/guest-header/guest-header.component';
import { SliderComponent } from './components/slider/slider.component';
import { BannerFeatureComponent } from './components/banner-feature/banner-feature.component';
import { HomeComponent } from './components/home/home.component';
import { CoursesComponent } from './components/courses/courses.component';
import { SeeAllHeaderComponent } from './components/see-all-header/see-all-header.component';
import { ErrorComponent } from './components/error/error.component';
import { CourseSingleComponent } from './components/course-single/course-single.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';
import { SecondrayHeaderComponent } from './components/secondray-header/secondray-header.component';
import { DepartmentsComponent } from './components/departments/departments.component';
import { DepartmentSingleComponent } from './components/department-single/department-single.component';
import { TeachersComponent } from './components/teachers/teachers.component';
import { TeacherSingleComponent } from './components/teacher-single/teacher-single.component';

import { CourseService } from './services/course.service';
import { TestComponent } from './components/test/test.component';
import { CookieService } from 'ngx-cookie-service';
import { AboutComponent } from './components/about/about.component';
import { TeachersListComponent } from './components/teachers-list/teachers-list.component';

const AppRoutes = [
  { path: '', component: HomeComponent },
  { path: 'test', component: TestComponent },
  { path: 'courses', component: CoursesComponent },
  { path: 'courses/:id', component: CourseSingleComponent },
  { path: 'departments', component: DepartmentsComponent },
  { path: 'departments/:id', component: DepartmentSingleComponent },
  { path: 'teachers', component: TeachersComponent },
  { path: 'teachers/:id', component: TeacherSingleComponent },
  { path: '**', component: ErrorComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    GuestHeaderComponent,
    SliderComponent,
    BannerFeatureComponent,
    HomeComponent,
    CoursesComponent,
    SeeAllHeaderComponent,
    ErrorComponent,
    CourseSingleComponent,
    CoursesListComponent,
    SecondrayHeaderComponent,
    DepartmentsComponent,
    DepartmentSingleComponent,
    TeachersComponent,
    TeacherSingleComponent,
    TestComponent,
    AboutComponent,
    TeachersListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(AppRoutes)

  ],
  providers: [CourseService,CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
