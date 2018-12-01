import React from 'react';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem } from 'reactstrap';



 class Header extends React.Component {
  constructor(props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render() {
    return (
      <header className="navbar navbar-expand navbar-dark flex-column flex-md-row bd-navbar">
        <Navbar>
          <NavbarBrand href="/">
          
        <img alt="Logo" src="https://lh3.googleusercontent.com/vFQ-srMQHCOelSE1VSytYLayJ0sVYg189xFa9RiVxC241wE4FysBm7uu86fzKV4-sg=s180-rw" width="36" />
&nbsp;Money Lover
</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
          <Collapse isOpen={this.state.isOpen} navbar>
            <Nav   >
              <NavItem>
                <NavLink href="/">Giới thiệu</NavLink>
              </NavItem>
              <NavItem>
                <NavLink href="#">Trợ giúp</NavLink>
              </NavItem>
              <UncontrolledDropdown nav inNavbar>
                <DropdownToggle nav caret>
                  Tài khoản
                </DropdownToggle>
                <DropdownMenu right>
                  <DropdownItem>
                    Thay đổi
                  </DropdownItem>
                  <DropdownItem>
                    Đổi mật khẩu
                  </DropdownItem>
                  <DropdownItem divider />
                  <DropdownItem>
                    Thoát
                  </DropdownItem>
                </DropdownMenu>
              </UncontrolledDropdown>
            </Nav>
          </Collapse>
        </Navbar>
        
      </header>
    );
  }
}

export default Header;