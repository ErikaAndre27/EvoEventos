import React, { useState } from 'react'
import './MainHome.css'
import CustomHeader from './components/customHeader'
import HeroSection from './components/HeroSection'
import CustomFooter from './components/CustomFooter'
import CustomMain from './components/CustomMain'
import Modal from './components/Modal'


const MainHome = () => {
    const [isOpen, setIsOpen] = useState(false)
    const openModal = () => setIsOpen(true)
    const closeModal = () => setIsOpen(false)
    return (
        <>
            {/* // HEADER */}
            <CustomHeader openModal={openModal} />
            {/* MAIN */}
            <HeroSection />
            <CustomMain />
            {/* FOOTER */}
            <CustomFooter />
            {/* {isOpen && (
                <Modal closeModal={closeModal} />
            )} */}


            <Modal closeModal={closeModal} isOpen={isOpen} />




        </>
    )
}

export default MainHome
