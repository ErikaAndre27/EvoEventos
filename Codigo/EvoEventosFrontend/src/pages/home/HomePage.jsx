import React, { useState } from 'react'
import './MainHome.css'
import CustomHeader from './components/CustomHeader/CustomHeader'
import HeroSection from './components/HeroSection/HeroSection'
import CustomFooter from './components/CustomFooter/CustomFooter'
import CustomMain from './components/CustomMain/CustomMain'
import Modal from './components/Modal/Modal'


const HomePage = () => {
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

export default HomePage
