import React from "react";
import { Link } from "react-router-dom";
import "./Navbar.css";

interface Props {}

const Navbar = (props: Props) => {
  return (
      <ul>
          <li><a href="/portfolio">Portfolio</a></li>
          <li><a href="/shares">Buy Share</a></li>
      </ul>
  );
};

export default Navbar;