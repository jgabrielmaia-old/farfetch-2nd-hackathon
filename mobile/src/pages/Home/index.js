import React from 'react';
import { SafeAreaView } from 'react-native';
import { Button, Divider, Layout, TopNavigation } from '@ui-kitten/components';

export const HomeScreen = ({ navigation }) => {

  return (
    <SafeAreaView style={{ flex: 1 }}>
      <TopNavigation title='Lookie looks' alignment='center'/>
      <Divider/>
      <Layout style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Button onPress={() => navigation.navigate('NewGame')}>New Game</Button>
        <Button onPress={() => navigation.navigate('AttributeSelection')}>Select Type</Button>
      </Layout>
    </SafeAreaView>
  );
};