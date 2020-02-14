import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout',
  template: ''
})
export class LogoutComponent implements OnInit {

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService.logout().subscribe(() => {
      console.log('User logged out successfully');
      this.router.navigate(['user/login']);
    }, error => console.error(error));
  }
}
