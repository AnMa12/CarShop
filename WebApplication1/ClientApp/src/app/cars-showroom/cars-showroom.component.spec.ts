import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CarsShowroomComponent } from './cars-showroom.component';

describe('CarsShowroomComponent', () => {
  let component: CarsShowroomComponent;
  let fixture: ComponentFixture<CarsShowroomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CarsShowroomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CarsShowroomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
