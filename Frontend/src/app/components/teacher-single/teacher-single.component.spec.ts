import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherSingleComponent } from './teacher-single.component';

describe('TeacherSingleComponent', () => {
  let component: TeacherSingleComponent;
  let fixture: ComponentFixture<TeacherSingleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TeacherSingleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeacherSingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
